using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

using ReflectSoftware.Insight.Common;
using ReflectSoftware.Insight.Common.Data;

using RI.Utils.Strings;
using RI.System.Configuration;
using RI.Data.SQL;

namespace ReflectSoftware.Insight.Listeners
{
    internal class ListenerDatabaseSql : IReflectInsightListener
    {
        private ConnectionStringSettings ConnectionSettings { get; set; }        
        private String SqlMessageIdentityTemplate { get; set; }
        private String SqlMessageStatementTemplate { get; set; }
        private String SqlMessageExtensionStatementTemplate { get; set; }
        private TransactionScopeOption TransactionOption { get; set; }
        private TimeSpan DelayRetryOnDbIssueTimeSpan { get; set; }
        private DateTime LastBadIssueDetected { get; set; }
        
        ///--------------------------------------------------------------------
        public void UpdateParameterVariables(IListenerInfo listener)
        {
            LastBadIssueDetected = DateTime.MinValue;

            String details = listener.Params["details"];
            if (StringHelper.IsNullOrEmpty(details))
                throw new ReflectInsightException(String.Format("Missing details parameter for listener: '{0}' using details: '{1}'.", listener.Name, listener.Details));

            ConfigNode settings = new ConfigNode(ReflectInsightConfig.Settings.XmlSection);
            if (!settings.IsSectionSet)
                throw new ReflectInsightException(String.Format("Cannot find Database Details node '{0}' in configuration settings.", details));                     
            
            ConfigNode dbSettings = settings.GetConfigNode(String.Format("./databaseDetails/details[@name='{0}']", details));
            if (dbSettings == null || !dbSettings.IsSectionSet)
                throw new ReflectInsightException(String.Format("Cannot find Database Details node '{0}' in configuration settings.", details));                     

            String connectionStringName = dbSettings.GetNodeInnerText("connectionStringName", String.Empty);
            if (StringHelper.IsNullOrEmpty(connectionStringName))
                throw new ReflectInsightException(String.Format("connectionStringName node text value for Database Details '{0}' in configuration settings is required.", details));

            ConnectionSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (ConnectionSettings == null)
                throw new ReflectInsightException(String.Format("Could not properly create Database Connection Settings using connection string: '{0}' for Database Details '{1}'.", connectionStringName, details));

            DelayRetryOnDbIssueTimeSpan = TimeSpan.FromSeconds(Int32.Parse(dbSettings.GetNodeInnerText("delayRetryOnDbIssue", "60")));

            SqlMessageIdentityTemplate = dbSettings.GetNodeInnerText("sqlMessageIdentity", String.Empty).ToLower();
            if (StringHelper.IsNullOrEmpty(SqlMessageIdentityTemplate))
                throw new ReflectInsightException(String.Format("sqlMessageIdentity node text value for Database Details '{0}' in configuration settings is required.", details));
                        
            SqlMessageStatementTemplate = dbSettings.GetNodeInnerText("sqlScriptMessage", String.Empty).ToLower();
            if (StringHelper.IsNullOrEmpty(SqlMessageStatementTemplate))
                throw new ReflectInsightException(String.Format("sqlScriptMessage node text value for Database Details '{0}' in configuration settings is required.", details));

            SqlMessageExtensionStatementTemplate = dbSettings.GetNodeInnerText("sqlScriptMessageExtension", String.Empty).ToLower();
            TransactionOption = dbSettings.GetNodeInnerText("transactionRequired", "false") == "false" ? TransactionScopeOption.Suppress : TransactionScopeOption.Required;
        }
        
        ///--------------------------------------------------------------------
        private static void AddParameter(String statement, SqlStatementParameterList paramList, String paramName, Object paramValue, DbType dbType)
        {
            if (statement.Contains(paramName))
                paramList.Add(paramName, paramValue, dbType, null, null);
        }

        ///--------------------------------------------------------------------
        private static String GetTextDetails(ReflectInsightPackage package)
        {
            if (!package.HasDetails || !package.IsDetail<DetailContainerString>())
                return null;

            return package.GetDetails<DetailContainerString>().FData;
        }

///--------------------------------------------------------------------
        private KeyRangeContainer GetKeyContainer(Int64 keyRange)
        {
            SqlStatementBuilder sb = new SqlStatementBuilder();
            SqlStatementParameterList paramList = new SqlStatementParameterList();

            paramList.Add("@range", keyRange, DbType.Int64, null, null);
            sb.Add(SqlMessageIdentityTemplate, paramList);
            
            Int64 nextKey;

            using (IDbConnection dbConnection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                using (IDbCommand command = sb.Build(dbConnection))
                {
                    dbConnection.Open();
                    try
                    {
                        nextKey = (Int64)command.ExecuteScalar();
                    }
                    finally
                    {
                        dbConnection.Close();
                    }
                }
            }

            return new KeyRangeContainer(nextKey, nextKey + keyRange - 1);
        }

        ///--------------------------------------------------------------------
        public void Receive(ReflectInsightPackage[] messages)
        {
            if (DateTime.Now.Subtract(LastBadIssueDetected) < DelayRetryOnDbIssueTimeSpan)
                return;

            List<ReflectInsightPackage> packages = messages.Where(p => p.FMessageType != MessageType.Clear && !RIUtils.IsViewerSpecificMessageType(p.FMessageType)).ToList();
            if (packages.Count == 0)
                return;

            try
            {
                KeyRangeContainer keys = GetKeyContainer(packages.Count); 
                SqlStatementBuilder sb = new SqlStatementBuilder();

                foreach (ReflectInsightPackage package in packages)
                {
                    Int64 riLogId = keys.GetNextKey();

                    SqlStatementParameterList messageParamList = new SqlStatementParameterList();
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "rilogid", riLogId, DbType.Int64);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "sessionid", package.FSessionID, DbType.Int64);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "requestid", package.FRequestID, DbType.Int64);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "sourceutcoffset", package.FSourceUtcOffset, DbType.Int16);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "datetime", package.FDateTime, DbType.DateTime);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "domainid", package.FDomainID, DbType.Int32);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "processid", package.FProcessID, DbType.Int32);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "threadid", package.FThreadID, DbType.Int32);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "category", package.FCategory, DbType.String);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "application", package.FApplication, DbType.String);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "machinename", package.FMachineName, DbType.String);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "userdomainname", package.FUserDomainName, DbType.String);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "username", package.FUserName, DbType.String);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "indentlevel", package.FIndentLevel, DbType.Int16);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "bkcolor", package.FBkColor.ToArgb(), DbType.Int32);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "messagetype", package.FMessageType, DbType.Int32);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "messagesubtype", package.FMessageSubType, DbType.Int16);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "message", package.FMessage, DbType.String);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "detailtype", package.FDetailType, DbType.Int32);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "subdetails", package.HasSubDetails ? package.FSubDetails.ObjectData : null, DbType.Binary);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "details", package.HasDetails ? package.FDetails.ObjectData : null, DbType.Binary);
                    AddParameter(SqlMessageStatementTemplate, messageParamList, "textdetails", GetTextDetails(package), DbType.String);

                    sb.Add(SqlMessageStatementTemplate, messageParamList);

                    if (package.HasExtendedProperties && !StringHelper.IsNullOrEmpty(SqlMessageExtensionStatementTemplate))
                    {
                        foreach (ReflectInsightExtendedProperties extension in package.FExtPropertyContainer.ExtendedProperties)
                        {
                            foreach (String key in extension.Properties.Keys)
                            {
                                SqlStatementParameterList extensionParamList = new SqlStatementParameterList();

                                AddParameter(SqlMessageExtensionStatementTemplate, extensionParamList, "rilogid", riLogId, DbType.Int64);
                                AddParameter(SqlMessageExtensionStatementTemplate, extensionParamList, "caption", extension.Caption, DbType.String);
                                AddParameter(SqlMessageExtensionStatementTemplate, extensionParamList, "extensionkey", key, DbType.String);
                                AddParameter(SqlMessageExtensionStatementTemplate, extensionParamList, "extensionvalue", extension.Properties[key], DbType.String);

                                sb.Add(SqlMessageExtensionStatementTemplate, extensionParamList);
                            }
                        }
                    }
                }

                using (TransactionScope txScope = new TransactionScope(TransactionOption))
                {
                    using (IDbConnection dbConnection = new SqlConnection(ConnectionSettings.ConnectionString))
                    {
                        List<IDbCommand> commands = sb.BuildChunks(dbConnection);

                        dbConnection.Open();
                        try
                        {
                            foreach (IDbCommand command in commands)
                            {
                                using (command)
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        finally
                        {
                            dbConnection.Close();
                        }
                    }

                    txScope.Complete();
                }
            }
            catch (Exception)
            {
                LastBadIssueDetected = DateTime.Now;
                throw;
            }
        }
    }
}
