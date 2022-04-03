using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    // localhost:port/api/products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products;

        public ProductsController()
        {
            _products = new List<Product>();
            _products.Add(new Product() { ProductId = 1, Name = "Samsung S6", Price = 3000, IsActive = false });
            _products.Add(new Product() { ProductId = 2, Name = "Samsung S7", Price = 4000, IsActive = false });
            _products.Add(new Product() { ProductId = 3, Name = "Samsung S8", Price = 5000, IsActive = false });
            _products.Add(new Product() { ProductId = 4, Name = "Samsung S9", Price = 6000, IsActive = false });
            _products.Add(new Product() { ProductId = 5, Name = "Samsung S10", Price = 7000, IsActive = true });
        }


        [HttpGet]
        public List<Product> GetProducts()
        {
            return _products;
        }
        // localhost:port/api/products/2
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var p = _products.FirstOrDefault(i => i.ProductId == id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);

        }
    }
}