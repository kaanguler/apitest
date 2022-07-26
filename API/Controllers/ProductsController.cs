﻿using API.Core.DbModels;
using API.Core.Interface;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //  private readonly StoreContext _context;

       // private readonly IProductRepository _productRepository;
      
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;


        public ProductsController(IGenericRepository<Product> productRepository, 
            IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;


        }




        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {

            var data = await _productRepository.ListAllAsync();
            return Ok(data);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {


            return Ok(await _productBrandRepository.ListAllAsync());

        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {


            return Ok(await _productTypeRepository.ListAllAsync());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            
            var data = await _productRepository.GetByIdAsync(id);

            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Ok(new Product());
            }
                
        }


       



    }
}
