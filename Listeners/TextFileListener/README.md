﻿# Text File Listener Sample

This sample will show you how to log to the **Text File** listener.

## Getting Started

### Installation

To install ReflectInsight, run the following command in the Package Manager Console:

```powershell
Install-Package ReflectSoftware.Insight
```

### Usage 

Add a using reference to the ReflectSoftware.Insight namespace.

```csharp
using ReflectSoftware.Insight;
```

Then for this sample we're going to use the default log manager for sending our log messages.

```csharp
RILogManager.Default.SendMessage("Message");
RILogManager.Default.SendDebug("Debug");
RILogManager.Default.SendInformation("Info");
RILogManager.Default.SendWarning("Warn");
RILogManager.Default.SendError("Error");
RILogManager.Default.SendFatal("Fatal");
RILogManager.Default.SendException("Exception", new Exception("Test"));
RILogManager.Default.SendMessage("Message");
```

### Configuration

Next we'll add the TextFile destination.

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the **configSections** with a section for for **"insightSettings"**:

    ```xml
    <configSections>
        <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
    </configSections>
    ```

3. Then add a new section called **"insightSettings"** as shown below and add the following basic settings:

    ```xml
    <insightSettings>
        <baseSettings>
            <configChange enabled="true"/>
            <enable state="all"/>
            <propagateException enabled="false"/>
            <exceptionEventTracker time="20" />
            <debugMessageProcess enabled="true" />
        </baseSettings>
    </insightSettings>  
    ```

4. Inside the **insightSettings** section, we need to define an **autoSave** value for our TextFile which looks like this. In this instance I'm showing all the defaults:
    
    ```xml
    <files default="">
      <autoSave name="save1" onNewDay="true" onMsgLimit="1000000" onSize="0" recycleFilesEvery="30" />
    </files>
    ```

5. Inside the **insightSettings** section, we need to define an **messagePattern** value for our TextFile which looks like this:
    
    ```xml
    <messagePatterns>
      <messagePattern name="pattern1" pattern="[%time{yyyyMMdd, HH:mm:ss.fff}%] - %message%,&amp;#xA;%threadid%&amp;#xA;[%messagetype%]" />
    </messagePatterns>
    ```

6. Next we need to define the **TextFile** listener as one of our logging destinations. Looking at the following, we can see
a new destination named "TextFile" and that its enabled with a filter definition set (this will exclude the Enter/Exit methods from showing up in the text file). 

    The text file **Log.txt** will be created in the working directory in a sub-folder called **Log** and will use our **autoSave** definition and **messagePattern** from above.

    ```xml
    <listenerGroups active="Debug">
      <group name="Debug" enabled="true" maskIdentities="false">
        <destinations>
          <destination name="TextFile" enabled="true" filter="EnterExitFilter" details="TextFile[path=$(workingdir)\Log\Log.txt; messageDetails=Message|Details; messagePattern=pattern1; autoSave=save1]" />
        </destinations>
      </group>
    </listenerGroups>
    ```

7. I mentioned we were using a message filter. Below I have defined a message filter to exclude certain message types from showing up in the Console:

    ```xml 
    <filters>
      <filter name="EnterExitFilter" mode="Exclude">
        <method type="EnterExitMethod" />
      </filter>
    </filters>
    ```

That's it your done! Build your app and check it out.

## Resources

Please refer to the ReflectInsight [Documentation](https://reflectsoftware.atlassian.net/wiki/display/RI5/ReflectInsight+5+documentation) for details on configuring ReflectInsight.
       
Feedback is always welcome on our [UserVoice](http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback).

Contact [support](support@reflectsoftware.com) for any help!