using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    [Table("OrderDetails"), MetadataType(typeof(OrderDetailsMetaData))]
    public class OrderDetails
    {
        public int OrderDetails_ID { get; set; }
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        public decimal Total_price { get; set; }

        [ForeignKey("Order_ID")]
        public virtual Order Order { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
    }
}