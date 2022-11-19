# Basic example of Tab Control. 
- How to add view to a tab in a tab control.
- One approach is to use View discovery. This is not the right approach for at least two reasons. 
- This example demonistrats the use of View discovery to add views to tabs.
- The first problem is as you can see below, there is if else conditions for adding views to tab. THis is not ideal.

```cs
void Navigate(string navigationPath)
{
    if(navigationPath == "ViewA")
        _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
    if (navigationPath == "ViewB")
        _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewB));
}
```

- The second problem is if I try to add an existing view which is already added to the tab control, we expect that the existing tab is shown up and the the same view is not added to the tab control by adding one more tab. This is not the case. 

![Tab Control](./images/20TabControl20.jpg)
