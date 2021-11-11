using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    [Table("CategoryType"), MetadataType(typeof(CategoryTypeMetaData))]
    public class CategoryType
    {
        public int CategoryType_ID { get; set; }
        public string CategoryType_Name { get; set; }
        public string CategoryType_Description { get; set; }

        public virtual ICollection<ProductCategoryTypes> ProductCategoryTypes { get; set; }
    }
}