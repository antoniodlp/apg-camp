using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace Odegi.Nop.Plugin.AuditLog
{
    public class RouteProvides : IRouteProvider
    {
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            #region FontEnd
            routeBuilder.MapRoute("Odegi.AuditLog.TopicHistory.List",
                "Admin/TopicHistory/List",
                new { controller = "TopicHistory", action = "List" }
            );

            routeBuilder.MapRoute("Odegi.AuditLog.TopicHistory.Edit",
                "Admin/TopicHistory/Edit",
                new { controller = "TopicHistory", action = "Edit" },
                new { id = @"\d+" }
            );

            routeBuilder.MapRoute("Odegi.AuditLog.TopicHistory.Create",
                "Admin/TopicHistory/Create",
                new { controller = "TopicHistory", action = "Create" }
            );
            
            routeBuilder.MapRoute("Odegi.AuditLog.TopicHistory.Compare",
                "Admin/TopicHistory/Compare",
                new { controller = "TopicHistory", action = "Compare" },
                new { id = @"\d+" }
            );

            /*routeBuilder.MapRoute("Odegi.B2B.CustomerAdresses",
                "b2b/customer-addresses",
                new { controller = "ECom", action = "CustomerAddresses" }
            );*/
            #endregion
            /*
            #region Customer Group
            routeBuilder.MapRoute("Odegi.B2B.CustomerGroupList",
                "Admin/CustomerGroup/CustomerGroupList",
                new { controller = "CustomerGroup", action = "CustomerGroupList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerGroupEdit",
                "Admin/CustomerGroup/CustomerGroupEdit/{id}",
                new { controller = "CustomerGroup", action = "CustomerGroupEdit" },
                new { id = @"\d+" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerGroupCreate",
                "Admin/CustomerGroup/CustomerGroupCreate",
                new { controller = "CustomerGroup", action = "CustomerGroupCreate" }
            );
            #endregion 

            #region Customer Section
            routeBuilder.MapRoute("Odegi.B2B.Customer",
                "Admin/B2BCustomer/Customer",
                new { controller = "B2BCustomer", action = "List" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerList",
                "Admin/B2BCustomer/CustomerList",
                new { controller = "B2BCustomer", action = "CustomerList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerEdit",
                "Admin/B2BCustomer/CustomerEdit/{id}",
                new { controller = "B2BCustomer", action = "CustomerEdit" },
                new { id = @"\d+" }
            );

            routeBuilder.MapRoute("Odegi.B2B.GetCartList",
                "Admin/B2BCustomer/GetCartList",
                new { controller = "B2BCustomer", action = "GetCartList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerAccountList",
                "Admin/B2BCustomer/CustomerAccountList",
                new { controller = "B2BCustomer", action = "CustomerAccountList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.AddressesSelect",
                "Admin/B2BCustomer/AddressesSelect",
                new { controller = "B2BCustomer", action = "AddressesSelect" }
            );

            routeBuilder.MapRoute("Odegi.B2B.AddressDelete",
                "Admin/B2BCustomer/AddressDelete",
                new { controller = "B2BCustomer", action = "AddressDelete" }            
            );
            #endregion

            #region ProductAccess
            routeBuilder.MapRoute("Odegi.B2B.ProductAccessList",
                "Admin/B2BCustomer/ProductAccessList",
                new { controller = "B2BCustomer", action = "ProductAccessList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.ProductAccessGetList",
                "Admin/B2BCustomer/ProductAccessGetList",
                new { controller = "B2BCustomer", action = "ProductAccessGetList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.GetSaleCodesFiltered",
                "Admin/B2BCustomer/GetSaleCodesFiltered",
                new { controller = "B2BCustomer", action = "GetSaleCodesFiltered" }
            );

            routeBuilder.MapRoute("Odegi.B2B.GetEntityCodesFiltered",
                "Admin/B2BCustomer/GetEntityCodesFiltered",
                new { controller = "B2BCustomer", action = "GetEntityCodesFiltered" }
            );

            routeBuilder.MapRoute("Odegi.B2B.ProductAccessInsert",
                "Admin/B2BCustomer/ProductAccessInsert",
                new { controller = "B2BCustomer", action = "ProductAccessInsert" }
            );

            routeBuilder.MapRoute("Odegi.B2B.ProductAccessUpdate",
                "Admin/B2BCustomer/ProductAccessUpdate",
                new { controller = "B2BCustomer", action = "ProductAccessUpdate" }
            );

            routeBuilder.MapRoute("Odegi.B2B.ProductAccessDelete",
                "Admin/B2BCustomer/ProductAccessDelete",
                new { controller = "B2BCustomer", action = "ProductAccessDelete" }
            );
            #endregion

            #region Customer Price
            routeBuilder.MapRoute("Odegi.B2B.CustomerPriceList",
                "Admin/CustomerPrice/CustomerPriceList",
                new { controller = "CustomerPrice", action = "CustomerPriceList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerPriceGetList",
                "Admin/CustomerPrice/CustomerPriceGetList",
                new { controller = "CustomerPrice", action = "CustomerPriceGetList" }
            );
            #endregion

            #region Customer Group Mapping
            routeBuilder.MapRoute("Odegi.B2B.CustomerGroupAssign",
                "Admin/CustomerGroup/CustomerGroupAssign",
                new { controller = "CustomerGroup", action = "CustomerGroupAssign" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerGroupAssignGet",
                "Admin/CustomerGroup/CustomerGroupAssignGet",
                new { controller = "CustomerGroup", action = "CustomerGroupAssignGet" }
            );

            routeBuilder.MapRoute("Odegi.B2B.GetGroupFiltered",
                "Admin/CustomerGroup/GetGroupFiltered",
                new { controller = "CustomerGroup", action = "GetGroupFiltered" }
            );

            routeBuilder.MapRoute("Odegi.B2B.GetCustomerFiltered",
                "Admin/CustomerGroup/GetCustomerFiltered",
                new { controller = "CustomerGroup", action = "GetCustomerFiltered" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerGroupMappingInsert",
                "Admin/CustomerGroup/CustomerGroupMappingInsert",
                new { controller = "CustomerGroup", action = "CustomerGroupMappingInsert" }
            );

            routeBuilder.MapRoute("Odegi.B2B.CustomerGroupMappingDelete",
                "Admin/CustomerGroup/CustomerGroupMappingDelete",
                new { controller = "CustomerGroup", action = "CustomerGroupMappingDelete" }
            );
            #endregion

            #region Accounts Section
            routeBuilder.MapRoute("Odegi.B2B.AccountList",
                "Admin/Account/AccountList",
                new { controller = "Account", action = "AccountList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.AccountEdit",
                "Admin/Account/AccountEdit/{id}",
                new { controller = "Account", action = "AccountEdit" },
                new { id = @"\d+" }
            );

            routeBuilder.MapRoute("Odegi.B2B.GetAccountList",
                "Admin/Account/GetAccountList",
                new { controller = "Account", action = "GetAccountList" }
            );

            //Actions
            
            routeBuilder.MapRoute("Odegi.B2B.Account.BackInStockSubscriptionList",
                "Plugins/B2B/BackInStockSubscriptionList",
                new { controller = "Account", action = "BackInStockSubscriptionList" }
            );

            routeBuilder.MapRoute("Odegi.B2B.Account.RewardPointsHistorySelect",
                "Plugins/B2B/RewardPointsHistorySelect",
                new { controller = "Account", action = "RewardPointsHistorySelect" }
            );

            routeBuilder.MapRoute("Odegi.B2B.Account.ListActivityLog",
                "Plugins/B2B/ListActivityLog",
                new { controller = "Account", action = "ListActivityLog" }
            );

            routeBuilder.MapRoute("Odegi.B2B.Account.OrderList",
                "Plugins/B2B/OrderList",
                new { controller = "Account", action = "OrderList" }
            );
            #endregion

            #region Ecommerce - Account Select
            routeBuilder.MapRoute("Odegi.B2B.Ecom.AccountSelect",
                "AccountSelect",
                new { controller = "ECom", action = "AccountSelect" }
            );

            routeBuilder.MapRoute("Odegi.B2B.Ecom.ChangeCustomer",
                "Plugins/B2B/ChangeCustomer",
                new { controller = "ECom", action = "ChangeCustomer" }
            );
            #endregion

            //Admin - Configuration
            routeBuilder.MapRoute("Odegi.B2B.Configure",
                 "Plugins/B2B/Configure",
                 new { controller = "Configure", action = "ConfigurePage" }
            );
            */
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
