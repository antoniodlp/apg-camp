using Nop.Core.Domain.Catalog;
using System.Collections.Generic;

namespace Odegi.Nop.Plugin.AuditLog.Services
{
    public partial interface IAuditLogService
    {
        IList<global::Nop.Core.Domain.Catalog.Manufacturer> GetAuditLog(int customerId);
        IList<Manufacturer> GetAuditLog(int customerId, int storeId = 0);
    }
}
