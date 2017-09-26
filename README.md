# Angular Material theme for Blogifier
View the latest build of the theme on [www.bloodforge.com](http://www.bloodforge.com)

The purpose of this project is to create a theme for [blogifier](https://github.com/blogifierdotnet/Blogifier.Core) using AngularJS (1.x) and Google's Angular Material library.

The theme is designed to be a "single-page" theme, utilizing ui-router.

Copy the contents of the 'src' directory into your web application project, and configure your appsettings.json:

```
{
  ...
  "Blogifier": {    
    ...

    "BlogTheme": "AngularMaterial"

    ...
  }
}
```

In addition, one other setting must be changed in your Startup.cs file. The models used by blogifier do not serialize properly, so you'll need to update your Startup.cs file. The following line

```csharp
services.AddMvc();
```
needs to be changed to

```csharp
services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
```

The theme is compatible with the stable branch of Blogifier.Core, version 1.2.
