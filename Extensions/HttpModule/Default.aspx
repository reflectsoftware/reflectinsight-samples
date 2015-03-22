<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HttpModule_Sample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Some Title</title>
    <meta name="keywords" content="ASP.NET,ASP.NET MVC" />
    <link href="css/emptysample.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="scripts/emptysample.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="No Exception Test" onclick="Button_NoException"/><br /><br />
        <asp:Button ID="Button2" runat="server" Text="Some Exception Test 1" onclick="Button_Exception1" /><br /><br />
        <asp:Button ID="Button3" runat="server" Text="Some Exception Test 2" onclick="Button_Exception2" /><br /><br />
        <asp:Label ID="Label1" runat="server" Text="Label"/><br /><br />
    </div>
    <div>
    <img alt="" src="images/ri_logo_green.png"/> 
    </div>
    <p>
        <asp:TextBox ID="UserName" runat="server">SomeUserName</asp:TextBox><br />
        <asp:TextBox ID="Password" runat="server" TextMode="Password">123456</asp:TextBox><br />
        <asp:TextBox ID="SomeEditField" runat="server">Some text value</asp:TextBox><br />
    </p>
    <a href="Default.aspx?firstname=somefirstname&lastname=somelastname">Home</a>
    </form>
</body>
</html>
