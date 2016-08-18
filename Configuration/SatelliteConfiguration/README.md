# Satellite Configuration Sample

This sample demonstrates how to add the ReflectInsight configuration to your application with satellite configuration files. 

Satellite configuration files are configuration files that exist on their own in seperate configuration file.

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
RILogManager.Default.SendMessage("This is a logged message using satellite configuration.");
```

### Configuration

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the **configSections** with a section for for **"insightSettings"**:

    ```xml
    <configSections>
        <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
    </configSections>
    ```

3. Then add a new section called **"insightSettings"** and add the **externalConfigSource** to point to your external **ReflectInsight.config** file:

    ```xml
    <insightSettings externalConfigSource="ReflectInsight.config" />
    ```

4. Please make sure you update the **ReflectInsight.config** file property **'Copy to Output Directory'** to **'Copy always'**.
       
5. Finally you do not need to call the satellite configuration file **ReflectInsight.config**. You can name it how you want and in fact can locate it where you want. You just need to add a path to the location of the file.

That's it your done!

## Resources

Please refer to the ReflectInsight [Documentation](https://reflectsoftware.atlassian.net/wiki/display/RI5/ReflectInsight+5+documentation) for details on configuring ReflectInsight.
       
Feedback is always welcome on our [UserVoice](http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback).

Contact [support](support@reflectsoftware.com) for any help!