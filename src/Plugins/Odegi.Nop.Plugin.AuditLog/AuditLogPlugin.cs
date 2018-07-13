using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Menu;
using Odegi.Nop.Plugin.AuditLog.Infrastructure;

namespace Odegi.Nop.Plugin.AuditLog
{
    public class AuditLogPlugin : BasePlugin, IAdminMenuPlugin
    {
        #region Const

        private const string ResourceStringPath = "~/Plugins/Odegi.AuditLog/Localization/ResourceString_EN.xml";

        #endregion

        #region Fields

        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly WidgetSettings _widgetSettings;
        private readonly ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;

        #endregion

        #region Ctor

        public AuditLogPlugin(ISettingService settingService,
            IWebHelper webHelper, WidgetSettings widgetSettings,
            ILocalizationService localizationService,
            ILanguageService languageService)
        {
            this._settingService = settingService;
            this._webHelper = webHelper;
            this._widgetSettings = widgetSettings;
            this._localizationService = localizationService;
            this._languageService = languageService;
        }

        #endregion

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/AuditLog/Configure";
        }

        /// <summary>
        /// Gets a view component for displaying plugin in public store
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <param name="viewComponentName">View component name</param>
        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "OdegiAuditLog";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new AuditLogSettings
            {
                Enabled = true
            };
            _settingService.SaveSetting(settings);

            //locales
            InstallLocaleResources();

            CreateDatabaseObjects();

            base.Install();

            // mark widget as active
            _widgetSettings.ActiveWidgetSystemNames.Add(this.PluginDescriptor.SystemName);
            _settingService.SaveSetting(_widgetSettings);
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<AuditLogSettings>();

            //locales
            DeleteLocalResources();

            base.Uninstall();

            // mark widget as disabled
            _widgetSettings.ActiveWidgetSystemNames.Remove(this.PluginDescriptor.SystemName);
            _settingService.SaveSetting(_widgetSettings);
        }

        public void ManageSiteMap(SiteMapNode rootNode)
        {
            //Topic Module Delete & Repalce with Plugin Admin Topic
            var nodeContentManagement = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Content Management");
            var nodeTopic = nodeContentManagement.ChildNodes.FirstOrDefault(x => x.SystemName == "Topics");
            nodeTopic.ControllerName = "TopicHistory";
            

            var manufacturersConfigureMenu = new SiteMapNode()
            {
                SystemName = "Odegi.AuditLog",
                Title = _localizationService.GetResource("Odegi.Plugin.AuditLog.Configure"),
                ControllerName = "AuditLog",
                ActionName = "Configure",
                Visible = true,
                IconClass = "fa-dot-circle-o"
            };

            var nopAdvanceMenu = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Odegi");
            if (nopAdvanceMenu == null)
            {
                nopAdvanceMenu = new SiteMapNode()
                {
                    SystemName = "Odegi",
                    Title = "Odegi",
                    Visible = true,
                    IconClass = "icon-nop-odegi"
                };
                nopAdvanceMenu.ChildNodes.Add(manufacturersConfigureMenu);
                rootNode.ChildNodes.Add(nopAdvanceMenu);
            }
            else
                nopAdvanceMenu.ChildNodes.Add(manufacturersConfigureMenu);



        }

        #region Utilities

        // <summary>
        ///Import Resource string from xml and save
        /// </summary>
        protected virtual void InstallLocaleResources()
        {
            foreach (var lang in _languageService.GetAllLanguages(true))
            {
                var localesXml = File.ReadAllText(CommonHelper.MapPath(ResourceStringPath));
                _localizationService.ImportResourcesFromXml(lang, localesXml);
            }
        }

        ///<summry>
        ///Delete Resource String
        ///</summry>
        protected virtual void DeleteLocalResources()
        {
            foreach (var lang in _languageService.GetAllLanguages(true))
            {
                var languageResourceNames = from name in XDocument.Load(CommonHelper.MapPath(ResourceStringPath)).Document.Descendants("LocaleResource")
                                            select name.Attribute("Name").Value;

                foreach (var item in languageResourceNames)
                {
                    this.DeletePluginLocaleResource(item);
                }
            }
        }

        #endregion


        private void CreateDatabaseObjects()
        {
            //Create Table for History Changes
            string sql = @"create table TopicHistory(Id int identity(1,1) primary key not null, TopicId int not null, Title nvarchar(500), Body nvarchar(max), UpdatedById int not null, UpdatedBy nvarchar(50), UpdatedOnUtc datetime not null, ApprovedBy nvarchar(50), ApprovedOnUtc datetime)";
            DataHelper.ExecuteSql(sql);
        }
    }
}