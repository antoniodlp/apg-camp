using Nop.Web.Framework.Mvc.Models;
using System.Collections.Generic;
using Odegi.Nop.Plugin.AuditLog.Models;

namespace Odegi.Nop.Plugin.TopManufacturers.Models
{
    public class AuditLogsModel : BaseNopEntityModel
    {
        public AuditLogsModel()
        {
            AuditLog = new List<AuditLogModel>();
        }

        public IList<AuditLogModel> AuditLog{ get; set; }

        public string CustomerName { get; set; }

    }
}
