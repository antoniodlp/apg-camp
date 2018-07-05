using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Services.Events;
using Nop.Web.Framework.Events;

namespace Nop.Plugin.Misc.Cms
{
    public class AdminTabStripConsumer : IConsumer<AdminTabStripCreated>
    {
        public void HandleEvent(AdminTabStripCreated tabEventInfo)
        {

            if (tabEventInfo != null && !string.IsNullOrEmpty(tabEventInfo.TabStripName))
            {
                if (tabEventInfo.TabStripName == "product-edit")
                {
                    
                    object objectId = tabEventInfo.Helper.ViewContext.RouteData.Values["id"];


                    var urlHelper = new UrlHelper(tabEventInfo.Helper.ViewContext);
                    
                    if (!string.IsNullOrEmpty(objectId.ToString()))
                    {
                        string text = "Additional tab";
                        var content = urlHelper.Action("CmsTopic", "TopicDetails", new { id = objectId });

                        tabEventInfo.BlocksToRender.Add(
                            new HtmlString(
                                "<script>"
                                    + "$(document).ready(function() {"
                                        + "$(\"<li><a data-tab-name='tab-name' data-toggle='tab' href='#tab-name'>New tab"
                                        + "</a></li> \").appendTo('#product-edit .nav-tabs:first');"

                                        + "$.get('" + content + "', function(result) {"
                                        + "$(\" <div class='tab-pane' id='tab-name'>\" + result + \"</div>\").appendTo('#category-edit .tab-content:first');"
                                        + "});"
                                    + "});"
                            + "</script>")
                        );
                    }
                }
            }
        }
    }
}
