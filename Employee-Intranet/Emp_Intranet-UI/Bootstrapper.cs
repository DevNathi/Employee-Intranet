using Emp_Intranet_UI.API.API_Helper;
using Emp_Intranet_UI.Controllers.LeaveHelpers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc3;

namespace Emp_Intranet_UI
{
    public class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<ILeaveLoader, LeaveLoader>();
            container.RegisterType<IApiHelper, ApiHelper>();

            return container;
        }


    }
}