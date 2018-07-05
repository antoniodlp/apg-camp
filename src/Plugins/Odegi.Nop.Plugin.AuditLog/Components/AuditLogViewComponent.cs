using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Media;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Seo;
using Nop.Web.Framework.Components;
using Odegi.Nop.Plugin.AuditLog.Models;
using Odegi.Nop.Plugin.AuditLog.Services;

namespace Odegi.Nop.Plugin.AuditLog.Components
{

    [ViewComponent(Name = "OdegiAuditLog")]
    public class AuditLogViewComponent : NopViewComponent
    {
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;
        private readonly IAuditLogService _topManufacturersService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly ICurrencyService _currencyService;
        private readonly CurrencySettings _currencySettings;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;
        private readonly MediaSettings _mediaSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerService _manufacturerService;
        

        public AuditLogViewComponent(IWorkContext workContext,
            IStoreContext storeContext,
            ISettingService settingService,
            IAuditLogService topManufacturersService,
            IPriceFormatter priceFormatter,
            ICurrencyService currencyService,
            CurrencySettings currencySettings,
            IDateTimeHelper dateTimeHelper,
            IPictureService pictureService,
            IWebHelper webHelper,
            MediaSettings mediaSettings,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService
            )
        {
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._settingService = settingService;
            this._topManufacturersService = topManufacturersService;
            this._priceFormatter = priceFormatter;
            this._currencyService = currencyService;
            this._currencySettings = currencySettings;
            this._dateTimeHelper = dateTimeHelper;
            this._pictureService = pictureService;
            this._webHelper = webHelper;
            this._mediaSettings = mediaSettings;
            this._localizationService = localizationService;
            this._manufacturerService = manufacturerService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            //int customerId = 0;

            //if(_workContext.CurrentCustomer.ParentCustomerId != 0)
            //    customerId = _workContext.CurrentCustomer.ParentCustomerId;

            //var manufacturerList = _topManufacturersService.GetAuditLog(customerId, _storeContext.CurrentStore.Id);

            //if (manufacturerList.Count == 0)
            //    return Content("");

            //var model = new ManufacturersModel();

            //foreach (var m in manufacturerList) {
            //    var altText = string.Format(_localizationService.GetResource("Media.Manufacturer.ImageAlternateTextFormat"), m.Name);
            //    var manufacturer = _manufacturerService.GetManufacturerById(m.Id);
            //    var manUrl = Url.RouteUrl("Manufacturer", new { SeName = manufacturer.GetSeName() });
            //    //urlHelper.RouteUrl("Manufacturer", new { SeName = manufacturer.GetSeName() }, GetHttpProtocol());
            //    model.Manufacturers.Add(new ManufacturerModel() { ManufacturerId = m.Id, ImageUrl= GetImage(m.PictureId), AltText= altText, Url = manUrl });
            //}

            //if (widgetZone == "home_page_bottom" || widgetZone == "od_top_manufacturer") {  // "header_selectors"  //od_top_manufacturers
            //    var topManufacturersSettings = _settingService.LoadSetting<AuditLogSettings>(_storeContext.CurrentStore.Id);
            //    if(topManufacturersSettings.Enabled)
            //        return View("~/Plugins/Odegi.AuditLog/Views/Public/_AuditLog.cshtml", model);
            //}
            return Content("");
        }

        private string GetImage(int pictureId)
        {
            string image = "";

            if (pictureId > 0)
                image = _pictureService.GetPictureUrl(pictureId, targetSize: _mediaSettings.ManufacturerThumbPictureSize, showDefaultPicture: false);

            if (string.IsNullOrEmpty(image))
                image = _pictureService.GetDefaultPictureUrl(_mediaSettings.ManufacturerThumbPictureSize);

            return image;
        }
    }
}
