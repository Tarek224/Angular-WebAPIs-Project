using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
    public class ProductDto
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public decimal Product_Price { get; set; }
        public string Product_Image { get; set; }
        public string Product_Size { get; set; }
        public string Product_Color { get; set; }
        public string Category_Name { get; set; }
    }
    public class CartDto
    {
        public int Cart_ID { get; set; }
        public int Product_ID { get; set; }
        public int Product_Quantity { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public string Product_Image { get; set; }
    }

    public class UserDto
    {
        public string User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
    }

    public class UserProductsDto
    {
        public int Product_ID { get; set; }
        public string Customer_ID { get; set; }
    }

    public class OrderDetailsDto
    {
        public int OrderDetails_ID { get; set; }
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        public decimal Total_price { get; set; }
    }

    public class ShippingDto
    {
        public int Shipping_ID { get; set; }
        public string Shipping_Email { get; set; }
        public string Shipping_FName { get; set; }
        public string Shipping_LName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int? Postal_Code { get; set; }
        public Cities City { get; set; }
        public long Phone1 { get; set; }
        public long? Phone2 { get; set; }
        public string Notes { get; set; }
    }

}