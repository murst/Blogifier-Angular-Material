# Angular Material theme for Blogifier
View the latest build of the theme on [test.bloodforge.com](http://test.bloodforge.com)

The purpose of this project is to create a theme for [blogifier](https://github.com/blogifierdotnet/Blogifier.Core) using AngularJS (1.x) and Google's Angular Material library.

The theme is designed to be a "single-page" theme, utilizing ui-router.

Simply copy the contents of the 'src' directory into your web application project, and configure your appsettings.json:

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

The theme is currently compatible with the dev branch of Blogifier.Core. In the future, I will convert this to follow the stable branch.
