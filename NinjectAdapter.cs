using Ninject;
using Remnant.Dependency.Interface;
using System;

namespace Remnant.Dependency.Ninject
{
	public class NinjectAdapter : IContainer
	{
		private readonly IKernel _kernel;

		public NinjectAdapter(IKernel kernel)
		{
			_kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
		}

		public IContainer Clear()
		{
			throw new NotSupportedException("Clear not supprted for ninject for now.");
		}

		public IContainer DeRegister<TType>() where TType : class
		{
			throw new NotSupportedException("Deregister not supported for ninject for now.");
		}

		public IContainer DeRegister(object instance)
		{
			throw new NotSupportedException("Deregister not supported for ninject for now.");
	}

		public IContainer Register<TType>(object instance) where TType : class
		{
			_kernel.Bind<TType>().ToConstant(instance as TType);
			return this;
		}

		public IContainer Register(Type type, object instance)
		{
			_kernel.Bind(type).ToConstant(instance);
			return this;
		}

		public IContainer Register(object instance)
		{
			_kernel.Bind(instance.GetType()).ToConstant(instance);
			return this;
		}

		public IContainer Register<TType>() where TType : class, new()
		{
			_kernel.Bind<TType>().ToConstant(new TType());
			return this;
		}

		public IContainer Register<TType, TObject>()
			where TType : class
			where TObject : class, new()
		{
			_kernel.Bind<TType>().ToConstant(new TObject() as TType);
			return this;
		}

		public TType ResolveInstance<TType>() where TType : class
		{
			return _kernel.Get<TType>();
		}

		public TContainer InternalContainer<TContainer>() where TContainer : class
		{
			if (_kernel as TContainer == null)
				throw new InvalidCastException($"The internal container is of type {_kernel.GetType().FullName} and cannot be cast to {typeof(TContainer).FullName}");

			return _kernel as TContainer;
		}
	}
}
