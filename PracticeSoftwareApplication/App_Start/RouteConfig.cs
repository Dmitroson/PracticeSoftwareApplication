using PracticeSoftwareApplication.Controllers;
using PracticeSoftwareApplication.Controllers.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PracticeSoftwareApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Admin routes

            routes.MapRoute(
                name: "Admin_Default",
                url: "admin",
                defaults: new { controller = GeneralController.Name, action = "Index" }
            );

            routes.MapRoute(
                name: "Admin_Teachers_List",
                url: "admin/teachers",
                defaults: new { controller = TeachersController.Name, action = "Index" }
            );

            routes.MapRoute(
                name: "Admin_Teachers_Create",
                url: "admin/teachers/create",
                defaults: new { controller = TeachersController.Name, action = "Create" }
            );

            routes.MapRoute(
                name: "Admin_Teachers_Edit",
                url: "admin/teachers/edit/{id}",
                defaults: new { controller = TeachersController.Name, action = "Edit" }
            );

            routes.MapRoute(
                name: "Admin_Teachers_Delete",
                url: "admin/teachers/delete/{id}",
                defaults: new { controller = TeachersController.Name, action = "Delete" }
            );

            routes.MapRoute(
                name: "Admin_Subjects_List",
                url: "admin/subjects",
                defaults: new { controller = SubjectController.Name, action = "Index" }
            );

            routes.MapRoute(
                name: "Admin_Subjects_Create",
                url: "admin/subjects/create",
                defaults: new { controller = SubjectController.Name, action = "Create" }
            );

            routes.MapRoute(
                name: "Admin_Subjects_Edit",
                url: "admin/subjects/edit/{id}",
                defaults: new { controller = SubjectController.Name, action = "Edit" }
            );

            routes.MapRoute(
                name: "Admin_Subjects_Delete",
                url: "admin/subjects/delete/{id}",
                defaults: new { controller = SubjectController.Name, action = "Delete" }
            );

            routes.MapRoute(
                name: "Admin_Signin",
                url: "admin/signin",
                defaults: new { controller = AdminUserController.Name, action = "Login" }
            );

            routes.MapRoute(
                name: "Admin_Signup",
                url: "admin/signup",
                defaults: new { controller = AdminUserController.Name, action = "Register" }
            );

            #endregion

            routes.MapRoute(
                name: "Signin",
                url: "signin",
                defaults: new { controller = AccountController.Name, action = "Login" }
            );

            routes.MapRoute(
                name: "Signup",
                url: "signup",
                defaults: new { controller = AccountController.Name, action = "Register" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
