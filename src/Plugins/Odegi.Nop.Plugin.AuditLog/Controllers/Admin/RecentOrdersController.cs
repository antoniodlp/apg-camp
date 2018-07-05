using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Odegi.Nop.Plugin.AuditLog.Models;

namespace Odegi.Nop.Plugin.AuditLog.Controllers.Admin
{
    [Area(AreaNames.Admin)]
    public class AuditLogController : BasePluginController
    {
        private readonly IWorkContext _workContext;
        private readonly IStoreService _storeService;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public AuditLogController(IWorkContext workContext,
            IStoreService storeService,
            ISettingService settingService,
            ILocalizationService localizationService)
        {
            this._workContext = workContext;
            this._storeService = storeService;
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

        public IActionResult Configure()
        {
            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var topManufacturersSettings = _settingService.LoadSetting<AuditLogSettings>(storeScope);
            var model = new ConfigurationModel
            {
                Enabled = topManufacturersSettings.Enabled,
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.Enabled_OverrideForStore = _settingService.SettingExists(topManufacturersSettings, x => x.Enabled, storeScope);
            }

            return View("~/Plugins/Odegi.AuditLog/Views/Admin/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var topManufacturersSettings = _settingService.LoadSetting<AuditLogSettings>(storeScope);

            topManufacturersSettings.Enabled = model.Enabled;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            _settingService.SaveSettingOverridablePerStore(topManufacturersSettings, x => x.Enabled, model.Enabled_OverrideForStore, storeScope, false);
            
            //now clear settings cache
            _settingService.ClearCache();
            
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}