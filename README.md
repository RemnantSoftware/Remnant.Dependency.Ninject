# Remnant Dependency Ninject
Ninject dependency injection adapter


## Nuget package:

        Install-Package Remnant.Dependency.Ninject -Version 1.0.1
        
```csharp
var ninject = new StandardKernel();
var container = Container.Create("MyContainer", new NinjectAdapter(ninject));
```
