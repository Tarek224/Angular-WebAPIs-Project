using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    [MetadataType(typeof(UserProductsMetaData))]
    public class UserProducts
    {
        public int UserProducts_ID { get; set; }
        public string Customer_ID { get; set; }
        public int Product_ID { get; set; }
        public int Product_Quantity { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual ApplicationUser Customer { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
    }
}