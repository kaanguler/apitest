﻿using API.DATA.DataContext;
using API.DATA.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            var data = await _context.Products.ToListAsync();
            return data;
        }
        [HttpGet("{id}")]
        public  ActionResult<Product> GetProduct(int id)
        {

            return _context.Products.Find(id)!;
        }


    }
}
