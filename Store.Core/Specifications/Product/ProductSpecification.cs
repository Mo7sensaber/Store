using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications.Product
{
    public class ProductSpecification : BaseSpecifications<Store.Core.Entities.Product, int>
    {
        public ProductSpecification(int id):base(p=>p.Id==id)
        {
            ApplyInclud();
        }
        public ProductSpecification(ProductSpaceParams productSpace) :base(
            p=>
            (string.IsNullOrEmpty(productSpace.Search)||p.Name.ToLower().Contains(productSpace.Search))
            &&
            (!productSpace.BrandId.HasValue ||productSpace.BrandId==p.BrandId)
            &&
            (!productSpace.TypeId.HasValue || productSpace.TypeId == p.TypeId)
            )
        {
            if (!string.IsNullOrEmpty(productSpace.Sort))
            {
                switch (productSpace.Sort)
                {
                        
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p=> p.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.Name);
            }
            ApplyInclud();
            ApplyPagination(productSpace.PageSize * (productSpace.PageIndaex - 1), productSpace.PageSize);

        }
        private void ApplyInclud()
        {
            Include.Add(p => p.Brand);
            Include.Add(p => p.Type);
        }
    }
}
