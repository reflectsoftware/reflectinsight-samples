# Headless Configuration Sample

This sample demonstrates how to add the ReflectInsight configuration to your application using headless configuration.

Headless configuration means you don't need to update your app/web configuration with
references to the **insightSettings** configuration and you can load the configuration at runtime from a local or remote file.
 
## Getting Started

In this sample you will notice there is no application configuratoin file.

There are two satellite configuration files, **ReflectInsight.congfig** and then **ReflectInsight2.config** located in the **Other Config** sub-folder. Make sure these configuration files file property **'Copy to Output Directory'** is set to **'Copy always'**.
 
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

Looking at the source code in program.cs, we can see how to load the configuration file dynamically at runtime and then change it if needed:

```csharp
// Load the configuration file in the root of the application
ReflectInsightConfig.Control.SetExternalConfigurationMode(@"$(workingdir)\ReflectInsight.config");
    
// Log some messages
RILogManager.Default.SendMessage("Testing developer configuration mode...");
RILogManager.Default.SendMessage("Configuration full path: {0}", ReflectInsightConfig.Control.LastConfigFullPath);
RILogManager.Default.SendError("A Some Error: {0}", index);

// Load in the configuration file located in the sub-folder "Other Config". Before loading in the configuration, you want to clear the developer configuration mode
ReflectInsightConfig.Control.ClearExternalConfigurationMode();
ReflectInsightConfig.Control.SetExternalConfigurationMode(@"$(workingdir)\Other Config\ReflectInsight2.config");

// Log some messages
RILogManager.Default.SendMessage("Testing developer configuration mode...");
RILogManager.Default.SendMessage("Configuration full path: {0}", ReflectInsightConfig.Control.LastConfigFullPath);
RILogManager.Default.SendError("B Some Error: {0}", index);
```

That's it your done!

## Resources

Please refer to the ReflectInsight [Documentation](https://reflectsoftware.atlassian.net/wiki/display/RI5/ReflectInsight+5+documentation) for details on configuring ReflectInsight.
       
Feedback is always welcome on our [UserVoice](http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback).

Contact [support](support@reflectsoftware.com) for any help!