using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications.Product
{
    public class ProductWithCountSpecifcation:BaseSpecifications<Store.Core.Entities.Product,int>
    {
        public ProductWithCountSpecifcation(ProductSpaceParams productSpace) : base(
           p =>
            (string.IsNullOrEmpty(productSpace.Search) || p.Name.ToLower().Contains(productSpace.Search))
            &&
           (!productSpace.BrandId.HasValue || productSpace.BrandId == p.BrandId)
           &&
           (!productSpace.TypeId.HasValue || productSpace.TypeId == p.TypeId)
           )
        {
           
        }
    }
}
