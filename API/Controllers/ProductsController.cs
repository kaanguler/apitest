using API.Core.DbModels;
using API.Core.Interface;
using API.Core.Specification;
using API.Dtos;
using API.Infrastructure.DataContext;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
     
    public class ProductsController : BaseApiController
    {

        //  private readonly StoreContext _context;

       // private readonly IProductRepository _productRepository;
      
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, 
            IGenericRepository<ProductBrand> productBrandRepository, 
            IGenericRepository<ProductType> productTypeRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;


        }

 
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new  ProductWithProductTypeAndBrandsSpecifications();
          
            var data = await _productRepository.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(data));




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
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithProductTypeAndBrandsSpecifications(id);
            
          //  var data = await _productRepository.GetEntityWithSpec(spec);

             var product = await _productRepository.GetEntityWithSpec(spec);

            
            return _mapper.Map<Product, ProductToReturnDto>(product);

        }


       



    }
}
