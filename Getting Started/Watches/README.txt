Scratchpad Sample

The Watches panel is only available in the Live Viewer. The Watches panel allows you to display non-persistent information for quick 
and dirty data changes. 

This sample will show you how to start working with Watches.

1. Start by adding a using reference to the ReflectSofteare.Insight namespace.

   using ReflectSoftware.Insight;

2. Then for this sample we're going to track the mouse position when it's over the rectangle control. Everytime the mouse position event is fired,
   a message will be send to the Watch panel. Only when the mouse stops moving (no more events), will we see the last known position of the mouse.

   Point mousePoint = e.GetPosition(this);
   ri.ViewerSendWatch("Mouse Position", "({0},{1})", mousePoint.X, mousePoint.Y); 

   When calling the ViewerSendWatch, you will typically pass in the LabelID and then the value. If the LabelID is used more than once in your 
   code, then the value will get overriden and only the last instance will be displayed.

4. That's it your done! Build your app and check it out.


Additional Resources

Knowledge Base
http://reflectsoftware.uservoice.com/knowledgebase

User Feedback
http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback

Support
support@reflectsoftware.com