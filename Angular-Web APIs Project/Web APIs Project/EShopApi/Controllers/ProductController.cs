using EShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EShopApi.Controllers
{
    public class ProductController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [Route("api/products")]
        public IHttpActionResult GetProducts()
        {
            List<ProductDto> ProductList = new List<ProductDto>();
            var products = context.Products.OrderBy(m => m.Product_Image).ToList();
            foreach (var item in products)
            {
                ProductList.Add(new ProductDto
                {
                    Product_ID = item.Product_ID,
                    Description = item.Description,
                    Product_Color = item.Product_Color,
                    Product_Image = item.Product_Image,
                    Product_Name = item.Product_Name,
                    Product_Price = item.Product_Price,
                    Product_Size = item.Product_Size,
                    Category_Name = item.Category.Category_Name
                });
            };
            return Ok(ProductList);
        }

        [Route("api/productdetails/{id}")]
        public IHttpActionResult GetProductDetails(int id)
        {
            Product product = context.Products.FirstOrDefault(m => m.Product_ID == id);
            ProductDto productDto = new ProductDto()
            {
                Product_ID = product.Product_ID,
                Description = product.Description,
                Product_Color = product.Product_Color,
                Product_Image = product.Product_Image,
                Product_Name = product.Product_Name,
                Product_Price = product.Product_Price,
                Product_Size = product.Product_Size,
                Category_Name = product.Category.Category_Name
            };
            if (product != null)
                return Ok(productDto);
            else
                return BadRequest("This isn't available product");
        }

        [Route("api/InCategory/{CatID}")]
        public IHttpActionResult GetProductsWithCatergory(int CatID)
        {
            List<ProductDto> ProductList = new List<ProductDto>();
            var products = context.Products.Where(model => model.Category_ID == CatID).ToList();
            foreach (var item in products)
            {
                ProductList.Add(new ProductDto
                {
                    Product_ID = item.Product_ID,
                    Description = item.Description,
                    Product_Color = item.Product_Color,
                    Product_Image = item.Product_Image,
                    Product_Name = item.Product_Name,
                    Product_Price = item.Product_Price,
                    Product_Size = item.Product_Size,
                    Category_Name = item.Category.Category_Name
                });
            };
            return Ok(ProductList);
        }

        [Route("api/WithType/{TypeID}")]
        public IHttpActionResult GetProductsWithType(int TypeID)
        {
            List<ProductDto> ProductList = new List<ProductDto>();
            var products = context.ProductCategoryTypes.Where(model => model.CategoryType_ID == TypeID).Select(model => model.Product).ToList();
            foreach (var item in products)
            {
                ProductList.Add(new ProductDto
                {
                    Product_ID = item.Product_ID,
                    Description = item.Description,
                    Product_Color = item.Product_Color,
                    Product_Image = item.Product_Image,
                    Product_Name = item.Product_Name,
                    Product_Price = item.Product_Price,
                    Product_Size = item.Product_Size,
                    Category_Name = item.Category.Category_Name
                });
            };
            return Ok(ProductList);
        }
    }
}
