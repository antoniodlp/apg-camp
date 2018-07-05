using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.Sandbox
{
    public class CmsPlugin: BasePlugin
    {

        private readonly ISettingService _setinngService;
        private readonly IWebHelper _webHelper;

        public CmsPlugin(ISettingService iSettingService, IWebHelper webHelper)
        {
            _setinngService = iSettingService;
            _webHelper = webHelper;
        }

        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/Cms/Configure";
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
