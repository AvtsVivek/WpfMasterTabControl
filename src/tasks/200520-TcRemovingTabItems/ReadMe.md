# Basic example of Tab Control. 
- After Adding a close button to the tabs, we need to remove items from the tabs when the x button is clicked. 
- Create a TriggerAction to attach to this button, so when the button is clicked, we can run code to remove the TabItem from the TabControl. So the first thing we to do is make sure you add a reference to System. Windows. Interactivity, because this is where the TriggerAction lives. So we're going to add a new class, I'm going to call it the CloseTabAction, and then it's going to derive from TriggerAction of T, T being the button.

- Add a CloseTabAction class.

- Attach this action to the button click event.

```xml
<Button Grid.Column="1" Content="x">
    <i:Interaction.Triggers>
        <i:EventTrigger EventName="Click">
            <local:CloseTabAction/>
        </i:EventTrigger>
    </i:Interaction.Triggers>
</Button>
```

- Add the necessary namespaces as well. 

```xml
xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
xmlns:local="clr-namespace:SimplePrismShell"
xmlns:localViews="clr-namespace:SimplePrismShell.Views"
```

- Now run the app and observe. 
