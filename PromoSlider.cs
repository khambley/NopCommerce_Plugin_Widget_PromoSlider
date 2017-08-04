using Nop.Core.Plugins;
using Nop.Plugin.Widget.PromoSlider.Data;
using Nop.Services.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Nop.Plugin.Widget.PromoSlider
{
    //1. Add IWidgetPlugin inheritance, add in using statement, and have VS implement interface
    public class PromoSliderPlugin : BasePlugin, IWidgetPlugin
    {
        private PromoSliderObjectContext _context;

        public PromoSliderPlugin(PromoSliderObjectContext context)
        {
            _context = context;
        }
        //3. Copy methods from GetDisplayWidgetRoute under here, change actionName to configure and remove widgetZone pair
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "PromoSlider";
            routeValues = new RouteValueDictionary(){
                { "Namespaces", "Nop.Plugin.Widget.PromoSlider.Controllers" },
                {"area", null }
            };
        }
        //2. add actionName, controllerName, and routeValues to method
        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PromoSliderWidget";
            controllerName = "PromoSlider";
            routeValues = new RouteValueDictionary(){
                { "Namespaces", "Nop.Plugin.Widget.PromoSlider.Controllers" },
                {"area", null },
                {"widgetZone", widgetZone }
            };
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string>();
        }

        //Install and Uninstall methods called on our _Object Context class and NopCommerce's basePlugin classes
        // Nop.Core/Plugins/BasePlugin.cs
        public override void Install()
        {
            _context.Install();
            base.Install();
        }
        public override void Uninstall()
        {
            _context.Uninstall();
            base.Uninstall();
        }
    }
}
