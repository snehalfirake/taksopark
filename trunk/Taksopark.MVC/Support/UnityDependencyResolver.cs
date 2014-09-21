using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Taksopark.MVC.Support
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer _unityContainer;

        public UnityDependencyResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
        public object GetService(Type serviceType)
        {
            if (!_unityContainer.IsRegistered(serviceType))
            {
                return null;
            }
            else
            {
                return _unityContainer.Resolve(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!_unityContainer.IsRegistered(serviceType))
            {
                return new List<Object>();
            }
            else
            {
                return _unityContainer.ResolveAll(serviceType);
            }
        }
    }
}