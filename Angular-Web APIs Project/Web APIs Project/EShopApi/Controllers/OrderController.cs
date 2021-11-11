using EShopApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopApi.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpPost]
        [Route("api/makeorder")]
        public IHttpActionResult MakeOrder()
        {
            var user = context.Users.FirstOrDefault(model => model.Email == User.Identity.Name);
            var userorder = context.Orders.FirstOrDefault(model => model.Customer_ID == user.Id);
            if (userorder == null)
            {
                try
                {
                    decimal totalprice = 0;
                    var userProducts = context.UserProducts.Where(model => model.Customer_ID == user.Id).ToList();
                    foreach (var item in userProducts)
                    {
                        totalprice += (item.Product_Quantity * item.Product.Product_Price);
                    }
                    Order order = new Order
                    {
                        Customer_ID = user.Id,
                        Order_Status = 0,
                        Order_Total = totalprice
                    };
                    context.Orders.Add(order);
                    context.SaveChanges();
                    foreach (var item in userProducts)
                    {
                        OrderDetails orderDetails = new OrderDetails
                        {
                            Order_ID = order.Order_ID,
                            Product_ID = item.Product_ID,
                            Total_price = item.Product.Product_Price * item.Product_Quantity,
                        };
                        context.OrderDetails.Add(orderDetails);
                        context.SaveChanges();
                    }
                    List<CartDto> CartProducts = new List<CartDto>();
                    foreach (var item in userProducts)
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
            else
            {
                var orderdetails = context.OrderDetails.Where(model => model.Order.Customer_ID == user.Id).ToList();
                if (orderdetails.Count != 0)
                {
                    foreach (var item in orderdetails)
                    {
                        context.OrderDetails.Remove(item);
                        context.SaveChanges();
                    }
                    try
                    {
                        decimal totalprice = 0;
                        var userProducts = context.UserProducts.Where(model => model.Customer_ID == user.Id).ToList();
                        foreach (var item in userProducts)
                        {
                            totalprice += (item.Product_Quantity * item.Product.Product_Price);
                        }
                        var order = context.Orders.FirstOrDefault(model => model.Customer_ID == user.Id);
                        foreach (var item in userProducts)
                        {
                            OrderDetails orderDetails = new OrderDetails
                            {
                                Order_ID = order.Order_ID,
                                Product_ID = item.Product_ID,
                                Total_price = item.Product.Product_Price * item.Product_Quantity,
                            };
                            context.OrderDetails.Add(orderDetails);
                            context.SaveChanges();
                        }
                        List<CartDto> CartProducts = new List<CartDto>();
                        foreach (var item in userProducts)
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
                else
                {
                    try
                    {
                        decimal totalprice = 0;
                        var userProducts = context.UserProducts.Where(model => model.Customer_ID == user.Id).ToList();
                        foreach (var item in userProducts)
                        {
                            totalprice += (item.Product_Quantity * item.Product.Product_Price);
                        }
                        var order = context.Orders.FirstOrDefault(model => model.Customer_ID == user.Id);
                        foreach (var item in userProducts)
                        {
                            OrderDetails orderDetails = new OrderDetails
                            {
                                Order_ID = order.Order_ID,
                                Product_ID = item.Product_ID,
                                Total_price = item.Product.Product_Price * item.Product_Quantity,
                            };
                            context.OrderDetails.Add(orderDetails);
                            context.SaveChanges();
                        }
                        List<CartDto> CartProducts = new List<CartDto>();
                        foreach (var item in userProducts)
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

        [HttpPost]
        [Route("api/makeshipping")]
        public IHttpActionResult ReleasOrder(ShippingDto shippingDto)
        {
            try
            {
                Shipping shipping = new Shipping()
                {
                    Address1 = shippingDto.Address1,
                    Address2 = shippingDto.Address2,
                    City = shippingDto.City,
                    Notes = shippingDto.Notes,
                    Phone1 = shippingDto.Phone1,
                    Phone2 = shippingDto.Phone2,
                    Postal_Code = shippingDto.Postal_Code,
                    Shipping_Email = shippingDto.Shipping_Email,
                    Shipping_FName = shippingDto.Shipping_FName,
                    Shipping_LName = shippingDto.Shipping_LName
                };
                Shipping newShipping = context.Shippings.Add(shipping);
                context.SaveChanges();
                var user = context.Users.FirstOrDefault(model => model.Email == User.Identity.Name);
                var order = context.Orders.FirstOrDefault(model => model.Customer_ID == user.Id);
                order.Shipping_ID = newShipping.Shipping_ID;
                context.SaveChanges();
                return Created("", "Shipping Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
