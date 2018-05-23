using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.Sandbox.Models
{
    public class ConfigurationModel : BaseNopModel 
    {

        public int ActiveStoreScopeConfiguration { get; set; }

        [DisplayName("Widget content")]
        public string Content { get; set; }
        public bool ContentOverrideForStore { get; set; }

    }
}
