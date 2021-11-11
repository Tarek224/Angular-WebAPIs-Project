using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    [Table("Category"), MetadataType(typeof(CategoryMetaData))]
    public class Category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public string Category_Describtion { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}