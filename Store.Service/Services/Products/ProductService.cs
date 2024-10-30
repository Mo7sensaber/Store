using AutoMapper;
using Store.Core;
using Store.Core.Dtos.Products;
using Store.Core.Entities;
using Store.Core.Helper;
using Store.Core.Services.Contract;
using Store.Core.Specifications;
using Store.Core.Specifications.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeBrandDtos>> GetAllBrandsAsync()
        {
            var brands=await _unitOfWork.Repository<ProductBrand,int>().GetAllAsync();
            var mappedBrands= _mapper.Map<IEnumerable<TypeBrandDtos>>(brands);
            return mappedBrands;
        }

        public async Task<PaginationResponse<ProductDtos>> GetAllProductsAsync(ProductSpaceParams productSpace)
        {
            var spec = new ProductSpecification(productSpace);
            var mapProduct = _mapper.Map<IEnumerable<ProductDtos>>(await _unitOfWork.Repository<Product, int>().GetAllWithSpacAsync(spec));
            var countSpace = new ProductWithCountSpecifcation(productSpace);
            var count = await _unitOfWork.Repository<Product, int>().GetCountAsync(countSpace);

            return new PaginationResponse<ProductDtos>(productSpace.PageSize, productSpace.PageIndaex, count, mapProduct);
            
        }

        public async Task<IEnumerable<TypeBrandDtos>> GetAllTypesAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDtos>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync ());
        }

        public async Task<ProductDtos> GetProductById(int id)
        {
            var spec = new ProductSpecification(id);

            var product = await _unitOfWork.Repository<Product,int>().GetWithSpacAsync(spec);
            var mappedProduct= _mapper.Map<ProductDtos>(product);
            return mappedProduct;
        }
    }
}
