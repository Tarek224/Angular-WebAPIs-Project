using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    [Table("Product"), MetadataType(typeof(ProductMetaData))]
    public class Product
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int? Category_ID { get; set; }
        public string Description { get; set; }
        public decimal Product_Price { get; set; }
        public string Product_Image { get; set; }
        public string Product_Size { get; set; }
        public string Product_Color { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual ICollection<ProductCategoryTypes> ProductCategoryTypes { get; set; }

        public virtual ICollection<UserProducts> UserProducts { get; set; }
    }
}