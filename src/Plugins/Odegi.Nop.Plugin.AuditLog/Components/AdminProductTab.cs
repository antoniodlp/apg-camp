using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Services.Events;
using Nop.Web.Framework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
//using Microsoft.AspNetCore.Http;
using System.Web;

namespace Odegi.Nop.Plugin.AuditLog.Components
{
    public class AdminProductTab :  IConsumer<AdminTabStripCreated>
    {
        private readonly IHtmlHelper _htmlHelper;

        public AdminProductTab(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }


        public void HandleEvent(AdminTabStripCreated tabEventInfo)
        {
            if (tabEventInfo != null && !string.IsNullOrEmpty(tabEventInfo.TabStripName))
            {
                if (tabEventInfo.TabStripName == "product-edit")
                {
                    //var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

                    //object objectId = HttpContext.Current.Request.RequestContext.RouteData.Values["id"];
                    object objectId = "1"; // _htmlHelper.ViewContext.RouteData.Values["id"];

                    if (!string.IsNullOrEmpty(objectId.ToString()))
                    {
                        string text = "Additional tab";
                        //string content = urlHelper.Action("YourController", "YourAction", new { id = objectId });
                        string content = "/Plugins/Odegi.AuditLog/Views/Public/_AuditLog.cshtml";

                        tabEventInfo.BlocksToRender.Add(
                          new HtmlString(
                            "<script>" +
                              "$(document).ready(function() {" +
                                "$('#product-edit').data('kendoTabStrip').append(" +
                                  "[{" +
                                    "text: '" + text + "'," +
                                    "contentUrl: '" + content + "'" +
                                  "}]" +
                                ");" +
                              "});" +
                            "</script>"
                          )
                        );
                    }
                }
            }
        }


    }
}
