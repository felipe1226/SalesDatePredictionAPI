using SalesDatePredictionAPI.Modules.Customers.Domain;
using SalesDatePredictionAPI.Modules.Customers.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Customers.Services;
using SalesDatePredictionAPI.Modules.Customers.Services.Interfaces;
using SalesDatePredictionAPI.Modules.Employees.Domain;
using SalesDatePredictionAPI.Modules.Employees.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Employees.Services;
using SalesDatePredictionAPI.Modules.Employees.Services.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.Domain;
using SalesDatePredictionAPI.Modules.Orders.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.Services;
using SalesDatePredictionAPI.Modules.Orders.Services.Interfaces;
using SalesDatePredictionAPI.Modules.Products.Domain;
using SalesDatePredictionAPI.Modules.Products.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Products.Services;
using SalesDatePredictionAPI.Modules.Products.Services.Interfaces;
using SalesDatePredictionAPI.Modules.Shippers.Domain;
using SalesDatePredictionAPI.Modules.Shippers.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Shippers.Services;
using SalesDatePredictionAPI.Modules.Shippers.Services.Interfaces;

namespace SalesDatePredictionAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterProfile(IServiceCollection services)
        {

            #region Services

            services.AddTransient<ICustomersServices, CustomersServices>();
            services.AddTransient<IEmployeesServices, EmployeesServices>();
            services.AddTransient<IOrdersServices, OrdersServices>();
            services.AddTransient<IProductsServices, ProductsServices>();
            services.AddTransient<IShippersServices, ShippersServices>();

            #endregion

            #region Domain

            services.AddTransient<ICustomersDomain, CustomersDomain>();
            services.AddTransient<IEmployeesDomain, EmployeesDomain>();
            services.AddTransient<IOrdersDomain, OrdersDomain>();
            services.AddTransient<IProductsDomain, ProductsDomain>();
            services.AddTransient<IShippersDomain, ShippersDomain>();

            #endregion

        }
    }
}

