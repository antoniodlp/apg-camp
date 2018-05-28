using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;

namespace Nop.Plugin.Widgets.Sandbox
{
    public class SandboxPlugin: BasePlugin, IWidgetPlugin
    {

        private readonly ISettingService _setinngService;
        private readonly IWebHelper _webHelper;

        public SandboxPlugin(ISettingService iSettingService, IWebHelper webHelper)
        {
            _setinngService = iSettingService;
            _webHelper = webHelper;
        }


        public IList<string> GetWidgetZones()
        {
            return new List<string>() {"home_page_top", "sandbox_page_footer"};
        }

        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsSandbox/Configure";
        }

        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "Sandbox";
        }

        public override void Install()
        {
            var settings = new SandboxSettings()
            {
                Content = ""
            };

            _setinngService.SaveSetting(settings);

            base.Install();
        }

        public override void Uninstall()
        {
            _setinngService.DeleteSetting<SandboxSettings>();

            base.Uninstall();
        }

    }
}
