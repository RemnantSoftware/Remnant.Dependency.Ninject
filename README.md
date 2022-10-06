# Remnant Dependency Ninject
Ninject dependency injection adapter


## Nuget package:

        Install-Package Remnant.Dependency.Ninject -Version 1.1.0

Create container for Ninject
```csharp
var ninject = new StandardKernel();
var container = Container.Create("MyContainer", new NinjectAdapter(ninject));
```

Get direct access to the internal DI container
```csharp
var ninject = Container.Instance.InternalContainer<StandardKernel>();
```
