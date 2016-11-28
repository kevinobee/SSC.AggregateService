using System;
using System.ComponentModel.DataAnnotations;
using Sitecore.Services.Core.Model;

namespace CustomService.Model
{
    public class Order : EntityIdentity
    {
        public Order(string id, string description, DateTime purchaseTimestamp)
        {
            Id = id;
            Description = description;
            PurchaseTimestamp = purchaseTimestamp;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Short Description")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PurchaseTimestamp { get; set; }
    }
}