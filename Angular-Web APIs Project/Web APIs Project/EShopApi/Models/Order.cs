using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    [Table("Order"), MetadataType(typeof(OrderMetaData))]
    public class Order
    {
        public int Order_ID { get; set; }
        public string Customer_ID { get; set; }
        public int? Shipping_ID { get; set; }
        public int? Payment_ID { get; set; }
        public decimal Order_Total { get; set; }
        public int Order_Status { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual ApplicationUser Customer { get; set; }
        [ForeignKey("Shipping_ID")]
        public virtual Shipping Shipping { get; set; }
        [ForeignKey("Payment_ID")]
        public virtual Payment Payment { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}