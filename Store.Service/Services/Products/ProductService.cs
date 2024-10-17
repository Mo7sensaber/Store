using AutoMapper;
using Store.Core;
using Store.Core.Dtos.Products;
using Store.Core.Entities;
using Store.Core.Services.Contract;
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

        public async Task<IEnumerable<ProductDtos>> GetAllProductsAsync()
        {
            return _mapper.Map<IEnumerable<ProductDtos>>(await _unitOfWork.Repository<Product, int>().GetAllAsync());
            
        }

        public async Task<IEnumerable<TypeBrandDtos>> GetAllTypesAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDtos>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync ());
        }

        public async Task<ProductDtos> GetProductById(int id)
        {
            var product= await _unitOfWork.Repository<Product,int>().GetAsync(id);
            var mappedProduct= _mapper.Map<ProductDtos>(product);
            return mappedProduct;
        }
    }
}
