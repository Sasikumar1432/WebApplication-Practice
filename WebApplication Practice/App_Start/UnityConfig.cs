using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplication_Practice.IService;
using WebApplication_Practice.Service;

namespace WebApplication_Practice
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ILogin, LoginService>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}