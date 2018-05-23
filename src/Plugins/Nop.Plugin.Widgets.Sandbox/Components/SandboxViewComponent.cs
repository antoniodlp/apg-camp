using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.Sandbox.Models;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Sandbox.Components
{
    [ViewComponent]
    public class SandboxViewComponent: NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public SandboxViewComponent(IStoreContext storeContext, ISettingService settingService)
        {
            _storeContext = storeContext;
            _settingService = settingService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {

            var sandboxSettings = _settingService.LoadSetting<SandboxSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                Content = sandboxSettings.Content
            };

            return View("~/Plugins/Widgets.Sandbox/Views/PublicInfo.cshtml", model);

        }
    }
}
