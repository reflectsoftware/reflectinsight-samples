# Watches Sample

The Watches panel is only available in the ReflectInsight Live Viewer. The Watches panel allows you to display non-persistent information for quick 
and dirty data changes. 

This sample will show you how to start working with Watches with no configuration and the results will show up in the ReflectInsight Live Viewer.

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

Then for this sample we're going to track the mouse position when it's over the rectangle control. Everytime the mouse position event is fired,
a message will be send to the Watch panel. Only when the mouse stops moving (no more events), will we see the last known position of the mouse.

```csharp
Point mousePoint = e.GetPosition(this);
ri.ViewerSendWatch("Mouse Position", "({0},{1})", mousePoint.X, mousePoint.Y); 
```

When calling the ViewerSendWatch, you will typically pass in the LabelID and then the value. If the LabelID is used more than once in your 
code, then the value will get overriden and only the last instance will be displayed.

That's it your done! Build your app and check it out.


## Resources

Please refer to the ReflectInsight [Documentation](https://reflectsoftware.atlassian.net/wiki/display/RI5/ReflectInsight+5+documentation) for details on configuring ReflectInsight.
       
Feedback is always welcome on our [UserVoice](http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback).

Contact [support](support@reflectsoftware.com) for any help!