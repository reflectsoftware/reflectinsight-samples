# ReflectInsight Router Service Listener Sample

This sample will show you how to do distributed logging using the ReflectInsight **Router** Service listener.

This sample requires that the **ReflectInsight Router Service** is installed locally.

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
RILogManager.Default.SendMessage("This is a logged message using the ReflectInsight Router listener.");
```

### Configuration

Next we'll add the Console destination.

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

4. Now we need to configure the Router. We'll add the following section and take notice to the **name**, **hostname** and **port**. We will refer back to
    these values later.

    ```xml
    <routers>
      <router name="MyRouterTCP"
              type="RI.Messaging.ReadWriter.Implementation.TCP.TCPWriter,ReflectSoftware.Insight"
              hostname="localhost"
              port="10881"
              connectionTimeout="3000"/>
    </routers>
    ```

5. Next we need to define the **Router** listener as one of our logging destinations. Looking at the following, we can see
a new destination named "RouterTCP" and that its enabled with no filter and that the details are configured to use the **MyRouterTCP** that we configured above. 
    
    ```xml
    <listenerGroups active="Debug">
      <group name="Debug" enabled="true" maskIdentities="false">
        <destinations>
          <destination name="RouterTCP" enabled="true" filter="" details="Router[name=MyRouterTCP]" />
        </destinations>
      </group>
    </listenerGroups>
    ```

That's it your done! Your application will now send all logged messages to the local Router. Please checkout the reference links before for 
configuring the ReflectInsight Live Viewer to connect to the router and receive live logging remotely.

## Resources

Checkout the [Getting Started Guide](https://reflectsoftware.atlassian.net/wiki/display/RI5/Getting+Started+with+the+Routing+Service) for the ReflectInsight Router Service and how to configure for your client applications.

Please refer to the ReflectInsight [Documentation](https://reflectsoftware.atlassian.net/wiki/display/RI5/ReflectInsight+5+documentation) for additional details on configuring ReflectInsight.
       
Feedback is always welcome on our [UserVoice](http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback).

Contact [support](support@reflectsoftware.com) for any help!
