using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Services.Catalog;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Tax;
using Nop.Web.Factories;
using Nop.Web.Framework.Controllers;
using Odegi.Nop.Plugin.AuditLog.Services;

namespace Odegi.Nop.Plugin.AuditLog.Controllers.Public
{
    public class AuditLogController : BasePluginController
    {
        #region Fields

        private readonly IProductService _productService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ILocalizationService _localizationService;
        private readonly IAuditLogService _topManufacturersService;
        private readonly IPermissionService _permissionService;
        private readonly ITaxService _taxService;
        private readonly OrderSettings _orderSettings;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly ICurrencyService _currencyService;
        private readonly IPictureService _pictureService;
        private readonly MediaSettings _mediaSettings;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IDownloadService _downloadService;
        private readonly IProductAttributeFormatter _productAttributeFormatter;

        #endregion

        #region Ctor

        public AuditLogController(IProductService productService
            ,IWebHelper webHelper,
            IStoreContext storeContext,
            IWorkContext workContext,
            IShoppingCartService shoppingCartService,
            ILocalizationService localizationService,
            IAuditLogService topManufacturersService,
            IPermissionService permissionService,
            IProductModelFactory productModelFactory,
            ITaxService taxService,
            OrderSettings orderSettings,
            IPriceCalculationService priceCalculationService,
            IPriceFormatter priceFormatter,
            ICurrencyService currencyService,
            IPictureService pictureService,
            MediaSettings mediaSettings,
            IStaticCacheManager cacheManager,
            IProductAttributeService productAttributeService,
            IProductAttributeParser productAttributeParser,
            IDownloadService downloadService,
            IProductAttributeFormatter productAttributeFormatter
            )
        {
            this._productService = productService;
            this._webHelper = webHelper;
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._shoppingCartService = shoppingCartService;
            this._localizationService = localizationService;
            this._topManufacturersService = topManufacturersService;
            this._permissionService = permissionService;
            this._taxService = taxService;
            this._orderSettings = orderSettings;
            this._priceCalculationService = priceCalculationService;
            this._priceFormatter = priceFormatter;
            this._currencyService = currencyService;
            this._pictureService = pictureService;
            this._mediaSettings = mediaSettings;
            this._cacheManager = cacheManager;
            this._productAttributeService = productAttributeService;
            this._productAttributeParser = productAttributeParser;
            this._downloadService = downloadService;
            this._productAttributeFormatter = productAttributeFormatter;
        }

        #endregion

        #region Methods 

        #endregion
    }
}
