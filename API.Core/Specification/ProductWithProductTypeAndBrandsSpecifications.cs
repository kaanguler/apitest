using API.Core.DbModels;
using API.Core.ISpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Specification
{
    public class ProductWithProductTypeAndBrandsSpecifications : BaseSpecification<Product>
    {
        public ProductWithProductTypeAndBrandsSpecifications()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductWithProductTypeAndBrandsSpecifications(int id) 
            :base(x=>x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
