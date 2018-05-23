using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.Sandbox.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.Sandbox.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsSandboxController: BasePluginController
    {
        private readonly IWorkContext _workContext;
        private readonly IStoreService _storeService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public WidgetsSandboxController(IWorkContext workContext, IStoreService storeService, IPermissionService permissionService, ISettingService settingService, ILocalizationService localizationService)
        {
            _workContext = workContext;
            _storeService = storeService;
            _permissionService = permissionService;
            _settingService = settingService;
            _localizationService = localizationService;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();


            var storeId = GetActiveStoreScopeConfiguration(_storeService, _workContext);

            var sandboxSettings = _settingService.LoadSetting<SandboxSettings>(storeId);

            var model = new ConfigurationModel()
            {
                Content = sandboxSettings.Content
            };

            if (storeId > 0)
            {
                model.ContentOverrideForStore = _settingService.SettingExists(sandboxSettings, x => x.Content, storeId);
            }

            return View("~/Plugins/Widgets.Sandbox/Views/Configure.cshtml", model);

        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var sandboxSettings = _settingService.LoadSetting<SandboxSettings>(storeScope);

            sandboxSettings.Content = model.Content;

            _settingService.SaveSettingOverridablePerStore(sandboxSettings, x => x.Content, model.ContentOverrideForStore, storeScope, false);
            _settingService.ClearCache();
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}
