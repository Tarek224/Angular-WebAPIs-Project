using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    public class CategoryMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_ID { get; set; }
        [Required, MaxLength(50)]
        public string Category_Name { get; set; }
    }
    public class OrderMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }
        [Required]
        public string Customer_ID { get; set; }
    }
    public class OrderDetailsMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetails_ID { get; set; }
    }
    public class ProductMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }

        [Required, MaxLength(50)]
        public string Product_Name { get; set; }

        [Required]
        public double Product_Price { get; set; }

        [Required]
        public string Product_Image { get; set; }

        [Required]
        public string Product_Size { get; set; }

        [Required]
        public string Product_Color { get; set; }
    }
    public class CategoryTypeMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryType_ID { get; set; }
        [Required, MaxLength(50)]
        public string CategoryType_Name { get; set; }
    }
    public class PaymentMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Payment_ID { get; set; }
    }
    public class ShippingMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Shipping_ID { get; set; }

        [Required, EmailAddress]
        public string Shipping_Email { get; set; }

        [Required, MaxLength(50)]
        public string Shipping_FName { get; set; }
        [Required, MaxLength(50)]
        public string Shipping_LName { get; set; }
        [Required, MaxLength(50)]
        public string Address1 { get; set; }
        [MaxLength(50)]
        public string Address2 { get; set; }
    }
    public class ProductCategoryTypesMetaData
    {
        [Key]
        public int ProductCategoryTypes_ID { get; set; }
    }
    public class UserProductsMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserProducts_ID { get; set; }
        [Required]
        public string Customer_ID { get; set; }
    }
}