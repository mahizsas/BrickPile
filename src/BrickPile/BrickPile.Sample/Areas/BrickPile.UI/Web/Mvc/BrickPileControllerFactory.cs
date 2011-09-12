﻿using System.Web.Mvc;
using System.Web.Routing;
using BrickPile.UI.Configuration;
using StructureMap;

namespace BrickPile.UI.Web.Mvc {
    public class BrickPileControllerFactory : DefaultControllerFactory {
        /// <summary>
        /// Creates the specified controller by using the specified request context.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <returns>
        /// The controller.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestContext"/> parameter is null.</exception>
        ///   
        /// <exception cref="T:System.ArgumentException">The <paramref name="controllerName"/> parameter is null or empty.</exception>
        public override IController CreateController(RequestContext requestContext, string controllerName) {
            if (!HasConfiguration()) {
                requestContext.RouteData.DataTokens["area"] = "dashboard";
                requestContext.RouteData.Values["action"] = "index";
                requestContext.RouteData.Values["controller"] = "setup";
                return base.CreateController(requestContext, "setup");
            }

            return base.CreateController(requestContext, controllerName);
        }
        /// <summary>
        /// Determines whether this instance has configuration.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has configuration; otherwise, <c>false</c>.
        /// </returns>
        private bool HasConfiguration() {
            var configuration = ObjectFactory.GetInstance<IConfiguration>();
            return configuration != null;
        }
    }
}