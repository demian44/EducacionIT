﻿using Microsoft.AspNetCore.Mvc;
using ProductsWebsite.Repositories;
using System.Linq;

namespace ProductsWebsite.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var products = _repository.GetProducts();
            return View(products);
        }

        public IActionResult GetProduct(int id)
        {
            var products = _repository.GetProducts();
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }

        public IActionResult GetImage(string name)
        {
            return File($@"images\{name}.png", "image/png");
        }
    }
}