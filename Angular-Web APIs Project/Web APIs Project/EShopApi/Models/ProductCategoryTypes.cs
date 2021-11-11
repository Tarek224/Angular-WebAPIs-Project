using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    [Table("ProductCategoryTypes"), MetadataType(typeof(ProductCategoryTypesMetaData))]
    public class ProductCategoryTypes
    {
        public int ProductCategoryTypes_ID { get; set; }
        public int? Product_ID { get; set; }
        public int? CategoryType_ID { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

        [ForeignKey("CategoryType_ID")]
        public virtual CategoryType CategoryType { get; set; }
    }
}