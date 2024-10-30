using Store.Core.Dtos.Products;
using Store.Core.Entities;
using Store.Core.Helper;
using Store.Core.Specifications.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services.Contract
{
    public interface IProductService
    {
        Task<PaginationResponse<ProductDtos>> GetAllProductsAsync(ProductSpaceParams productSpace);
        Task<IEnumerable<TypeBrandDtos>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDtos>> GetAllBrandsAsync();
        Task<ProductDtos> GetProductById(int id);
    }
}
