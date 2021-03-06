using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? 
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);

            await _productRepository.CreateAsync(productEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = _productRepository.GetProductCategoryAsync(id);

            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);

            await _productRepository.RemoveAsync(productEntity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);

            _productRepository.UpdateAsync(productEntity);
        }
    }
}
