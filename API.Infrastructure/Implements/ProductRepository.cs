﻿using API.Core.DbModels;
using API.Core.Interface;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

      

        public async Task<Product> GetProductByIdAsync(int Id)
        {
          
            
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {

            return await _context.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async  Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}
