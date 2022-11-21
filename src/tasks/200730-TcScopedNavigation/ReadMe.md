# Basic example of Tab Control. 
- This builds from the previous example. 
- The previous example demonistrates an exception that can occur. This example provides a solution to avoid such an exception.
- For each tab that is added to the tab control, a new view is added whtich has a region. Now each view should get its own region manager. So for that we do the following.

- Create a new interface like this.

```cs
public interface ICreateRegionManagerScope
{
    bool CreateRegionManagerScope { get; }
}
```    

- NExt we add a new class called ScopedRegionNavigationContentLoader and this is a [modified class from here](https://github.com/PrismLibrary/Prism/blob/master/src/Wpf/Prism.Wpf/Regions/RegionNavigationContentLoader.cs).
- Some of the modifications we have to do are as follows.



```cs
protected virtual void AddViewToRegion(IRegion region, object view)
{
    region.Add(view, null, CreateRegionManagerScope(view));
}
private bool CreateRegionManagerScope(object view)
{
    bool createRegionManagerScope = false;
    var viewHasScopedRegions = view as ICreateRegionManagerScope;
    if (viewHasScopedRegions != null)
        createRegionManagerScope = viewHasScopedRegions.CreateRegionManagerScope;
    return createRegionManagerScope;
}
private void AutowireViewModel(object viewOrViewModel)
{
    if (viewOrViewModel is FrameworkElement view && view.DataContext is null && ViewModelLocator.GetAutoWireViewModel(view) is null)
    {
        ViewModelLocator.SetAutoWireViewModel(view, true);
    }
}
```
- Next register this new class as follows in the bootstraper class.

```cs
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterSingleton<IRegionNavigationContentLoader, ScopedRegionNavigationContentLoader>();
}
```

- Finally impliment the interface to a view that has a region in it and which needs its own instance of region manager when ever a new view is created.

```cs
public partial class ViewA : UserControl, ICreateRegionManagerScope
{
    public bool CreateRegionManagerScope
    {
        get { return true; }
    }
}
```
- Now run the app. 
- Now each ViewA will get its own new region manager. But there is a problem