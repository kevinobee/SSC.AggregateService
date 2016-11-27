using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Sitecore.Services.Core.Model;

namespace CustomService.Model
{
    public class Customer : EntityIdentity
    {
        public Customer(string id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }

        private Customer()
        {
            Orders = new List<Order>();
        }
        
        [Required]
        public string Name { get; set; }

        #region Referenced Entities - Not supported by Entity Service

        [Required]
        public List<Order> Orders { get; set; }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        #endregion

        public static IOrderedQueryable<Customer> GetTopBuyer(Task<IQueryable<Customer>> customerQuery)
        {
            return customerQuery
                    .Result
                    .OrderByDescending(x => x.Orders.Count);
        }
    }
}