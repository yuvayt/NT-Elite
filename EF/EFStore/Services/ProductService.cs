using System;
using System.Collections.Generic;
using System.Linq;
using EFStore.Extensions;
using EFStore.Models.DTO;
using EFStore.Repositories.Interfaces;

namespace EFStore.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ProductDTO Add(ProductDTO dto)
        {
            if (dto == null)
            {
                return null;
            }
            var addingProduct = _unitOfWork.Products.Add(dto.ToEntity());
            _unitOfWork.SaveChanges();

            return addingProduct.ToDto();
        }
        public IEnumerable<ProductDTO> GetAll(FilterParameters parameters)
        {
            var products = _unitOfWork.Products.GetAll();
            var searchString = parameters.SearchString;
            var sortOrder = parameters.SortOrder;
            var pageSize = parameters.PageSize;
            var pageNumber = parameters.PageNumber;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(c => c.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(c => c.Name);
                    break;
                case "mfr_asc":
                    products = products.OrderBy(c => c.Manufacture);
                    break;
                case "mfr_desc":
                    products = products.OrderByDescending(c => c.Manufacture);
                    break;
                default:
                    products = products.OrderBy(c => c.Name);
                    break;
            }

            return products
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .Select(x => x.ToDto());
        }

        public ProductDTO GetById(Guid id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                return null;
            }

            return product.ToDto();
        }

        public bool Remove(Guid id)
        {
            var deleteProduct = _unitOfWork.Products.GetById(id);
            if (deleteProduct == null)
            {
                return false;
            }
            _unitOfWork.Products.Remove(deleteProduct);
            _unitOfWork.SaveChanges();

            return true;
        }

        public ProductDTO Update(ProductDTO dto)
        {
            var updateProduct = _unitOfWork.Products.GetById(dto.Id);
            if (updateProduct == null)
            {
                return null;
            }

            updateProduct = updateProduct.MappingProperties(dto);

            _unitOfWork.SaveChanges();

            return updateProduct.ToDto();
        }
    }
}