using System.Web.Mvc;
using Emp_Intranet_Manager_UI.API;
using Emp_Intranet_Manager_UI.API.API_Helper;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace Emp_Intranet_Manager_UI
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAPIHelper, APIHelper>();
            container.RegisterType<IUserEndPoint, UserEndPoint>();
            RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}