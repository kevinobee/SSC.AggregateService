using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomService.Model;
using Sitecore.Services.Core.Data;

namespace CustomService.Data
{
    public sealed class InMemoryReadOnlyEntityRepository

        : IReadOnlyEntityRepository<Customer>, 
          IReadOnlyEntityRepository<Order>
    {
        private static readonly IEnumerable<Customer> Customers;

        static InMemoryReadOnlyEntityRepository()
        {
            var orders = new[]
            {
                new Order(
                        CreateEntityId(), 
                        "first order", 
                        DateTime.UtcNow.AddDays(-5)),

                new Order(
                        CreateEntityId(), 
                        "second order", 
                        DateTime.UtcNow.AddMonths(-4)),

                new Order(
                        CreateEntityId(), 
                        "third order", 
                        DateTime.UtcNow.AddDays(-14))
            };

            var customers = new List<Customer>();

            var customer = new Customer(new Guid("cc564bd0-153f-450f-b04a-9d3cd76d5abd").ToString(), "Fred Smith");
            customer.AddOrder(orders[0]);
            customers.Add(customer);

            customer = new Customer(CreateEntityId(), "Pete Best");
            customer.AddOrder(orders[1]);
            customer.AddOrder(orders[2]);
            customers.Add(customer);

            Customers = customers;
        }

        private static IQueryable<Order> Orders
        {
            get
            {
                var orders = new List<Order>();

                foreach (var order in from customer in Customers
                                      from order in customer.Orders
                                      where !orders.Contains(order)
                                      select order)
                {
                    orders.Add(order);
                }

                return orders.AsQueryable();
            }
        }

        #region IReadOnlyEntityRepository<Customer>

        async Task<Customer> IReadOnlyEntityRepository<Customer>.GetById(string id)
        {
            return await Task.FromResult(Customers.Single(x => x.Id == id));
        }

        async Task<IQueryable<Customer>> IReadOnlyEntityRepository<Customer>.GetData()
        {
            return await Task.FromResult(Customers.AsQueryable());
        }

        #endregion

        #region IReadOnlyEntityRepository<Order>

        async Task<IQueryable<Order>> IReadOnlyEntityRepository<Order>.GetData()
        {
            return await Task.FromResult(Orders);
        }

        async Task<Order> IReadOnlyEntityRepository<Order>.GetById(string id)
        {
            return await Task.FromResult(Orders.Single(x => x.Id == id));
        }

        #endregion

        private static string CreateEntityId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}