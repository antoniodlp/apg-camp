using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Stores;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Odegi.Nop.Plugin.AuditLog.Services
{
    public partial class AuditLogService : IAuditLogService
    {
        #region Fields

        private readonly IManufacturerService _manufacturerService;
        private readonly IRepository<Manufacturer> _manufacturerRepository;
        private readonly CatalogSettings _catalogSettings;
        private readonly IRepository<StoreMapping> _storeMappingRepository;

        #endregion

        #region Ctor

        public AuditLogService(
            IRepository<Manufacturer> manufacturerRepository,
            IManufacturerService manufacturerService,
            CatalogSettings catalogSettings,
            IRepository<StoreMapping> storeMappingRepository
            )
        {
            this._manufacturerRepository = manufacturerRepository;
            this._manufacturerService = manufacturerService;
            this._catalogSettings = catalogSettings;
            this._storeMappingRepository = storeMappingRepository;
        }

        #endregion

        #region Methods

        public virtual IList<global::Nop.Core.Domain.Catalog.Manufacturer> GetAuditLog(int customerId)
        {
            var query = (from o in _manufacturerRepository.Table
                         where !o.Deleted
                         select o).OrderByDescending(x => x.DisplayOrder).Take(5).ToList();
            // return query;
            return null;

        }

        public virtual IList<Manufacturer> GetAuditLog(int customerId, int storeId=0)
        {
            var query = _manufacturerRepository.Table;
            query = query.Where(m => m.Published);           
            query = query.Where(m => !m.Deleted);
            //query = query.Where(m => m.IsFeatured);
            query = query.OrderBy(m => m.DisplayOrder).ThenBy(m => m.Id);

            if ((storeId > 0 && !_catalogSettings.IgnoreStoreLimitations) || (!_catalogSettings.IgnoreAcl))
            {
                //if (!_catalogSettings.IgnoreAcl)
                //{
                //    //ACL (access control list)
                //    var allowedCustomerRolesIds = _workContext.CurrentCustomer.GetCustomerRoleIds();
                //    query = from m in query
                //            join acl in _aclRepository.Table
                //            on new { c1 = m.Id, c2 = "Manufacturer" } equals new { c1 = acl.EntityId, c2 = acl.EntityName } into m_acl
                //            from acl in m_acl.DefaultIfEmpty()
                //            where !m.SubjectToAcl || allowedCustomerRolesIds.Contains(acl.CustomerRoleId)
                //            select m;
                //}
                if (storeId > 0 && !_catalogSettings.IgnoreStoreLimitations)
                {
                    //Store mapping
                    query = from m in query
                            join sm in _storeMappingRepository.Table
                            on new { c1 = m.Id, c2 = "Manufacturer" } equals new { c1 = sm.EntityId, c2 = sm.EntityName } into m_sm
                            from sm in m_sm.DefaultIfEmpty()
                            where !m.LimitedToStores || storeId == sm.StoreId
                            select m;
                }
                //only distinct manufacturers (group by ID)
                query = from m in query
                        group m by m.Id
                            into mGroup
                        orderby mGroup.Key
                        select mGroup.FirstOrDefault();
                query = query.OrderBy(m => m.DisplayOrder).ThenBy(m => m.Id);
            }

            var result = query.ToList();

            if (customerId != 0)
            {
                //DataSet ds = B2B.Core.Data.DataHelper.Query(String.Format("select id from OdgFnGetManufacturersAllowedCustomer({0});", customerId));
                //IList<int> manList = new List<int>();
                //foreach (DataRow row in ds.Tables[0].Rows)
                //    manList.Add(Convert.ToInt32(row["Id"]));

                //for (int i = result.Count - 1; i >= 0; i--)
                //    if (!manList.Contains(result[i].Id))
                //        result.RemoveAt(i);
            }

            return result;
        }

        

        #endregion
    }
}
