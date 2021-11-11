using EShopApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EShopApi.Controllers
{
    [Authorize]
    public class CartController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [Route("api/cart/products")]
        public IHttpActionResult GetProductsInCart()
        {
            List<UserProducts> products = context.UserProducts.Where(model => model.Customer.UserName == User.Identity.Name).ToList();
            List<CartDto> CartProducts = new List<CartDto>();
            foreach (var item in products)
            {
                CartProducts.Add(new CartDto
                {
                    Product_ID = item.Product_ID,
                    Product_Image = item.Product.Product_Image,
                    Product_Name = item.Product.Product_Name,
                    Product_Price = item.Product.Product_Price,
                    Product_Quantity = item.Product_Quantity,
                    Cart_ID = item.UserProducts_ID
                });
            };
            return Ok(CartProducts);
        }

        [HttpPost]
        [Route("api/addcart/{product_id}")]
        public IHttpActionResult PostAddToCart(int product_id)
        {
            try
            {
                var user = context.Users.FirstOrDefault(model => model.Email == User.Identity.Name);
                var product = context.Products.FirstOrDefault(model => model.Product_ID == product_id);

                UserProducts userProducts = new UserProducts
                {
                    Customer_ID = user.Id,
                    Product_ID = product.Product_ID,
                };

                context.UserProducts.Add(userProducts);
                context.SaveChanges();
                List<UserProducts> products = context.UserProducts.Where(model => model.Customer.UserName == User.Identity.Name).ToList();
                List<CartDto> CartProducts = new List<CartDto>();
                foreach (var item in products)
                {
                    CartProducts.Add(new CartDto
                    {
                        Product_ID = item.Product_ID,
                        Product_Image = item.Product.Product_Image,
                        Product_Name = item.Product.Product_Name,
                        Product_Price = item.Product.Product_Price,
                        Product_Quantity = item.Product_Quantity,
                        Cart_ID = item.UserProducts_ID
                    });
                };
                return Ok(CartProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Cart/{id}/{quantity}")]
        [HttpPut]
        public IHttpActionResult SetQuantity(int id, int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("The Quantity should be one or more than one .");
            }
            UserProducts userproduct = context.UserProducts.FirstOrDefault(model => model.UserProducts_ID == id);
            userproduct.Product_Quantity = quantity;
            context.SaveChanges();
            List<UserProducts> products = context.UserProducts.Where(model => model.Customer.UserName == User.Identity.Name).ToList();
            List<CartDto> CartProducts = new List<CartDto>();
            foreach (var item in products)
            {
                CartProducts.Add(new CartDto
                {
                    Product_ID = item.Product_ID,
                    Product_Image = item.Product.Product_Image,
                    Product_Name = item.Product.Product_Name,
                    Product_Price = item.Product.Product_Price,
                    Product_Quantity = item.Product_Quantity,
                    Cart_ID = item.UserProducts_ID
                });
            };
            return Ok(CartProducts);
        }
        [HttpDelete]
        [Route("api/delete/{cart_id}")]
        public IHttpActionResult DeleteFromCart(int cart_id)
        {
            try
            {
                var userProduct = context.UserProducts.FirstOrDefault(model => model.UserProducts_ID == cart_id);
                context.UserProducts.Remove(userProduct);
                context.SaveChanges();
                List<UserProducts> products = context.UserProducts.Where(model => model.Customer.UserName == User.Identity.Name).ToList();
                List<CartDto> CartProducts = new List<CartDto>();
                foreach (var item in products)
                {
                    CartProducts.Add(new CartDto
                    {
                        Product_ID = item.Product_ID,
                        Product_Image = item.Product.Product_Image,
                        Product_Name = item.Product.Product_Name,
                        Product_Price = item.Product.Product_Price,
                        Product_Quantity = item.Product_Quantity,
                        Cart_ID = item.UserProducts_ID
                    });
                };
                return Ok(CartProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
