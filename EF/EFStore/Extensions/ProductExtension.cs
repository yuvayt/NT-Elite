using System;
using System.Collections.Generic;
using System.Linq;
using EFStore.Models.DTO;
using EFStore.Models.Entities;

namespace EFStore.Extensions
{
    public static class ProductExtension
    {
        public static Product ToEntity(this ProductDTO dto)
        {
            var entity = new Product
            {
                ProductCategories = new List<ProductCategory>()
            };

            entity = MappingProperties(entity, dto);

            return entity;
        }
        public static ProductDTO ToDto(this Product entity)
        {
            return new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Manufacture = entity.Manufacture,
                CategoryIds = entity.ProductCategories.Select(pc => pc.CategoryId)
            };
        }
        public static Product MappingProperties(this Product entity, ProductDTO dto)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Manufacture = dto.Manufacture;

            foreach (var id in dto.CategoryIds)
            {
                entity.ProductCategories.Add(new ProductCategory
                {
                    CategoryId = id,
                });
            }

            return entity;
        }
        // public static void FilterInput(Product product, IEnumerable<Guid> guids)
        // {
        //     foreach (var id in guids)
        //     {
        //         if (_unitOfWork.Categories.GetById(id) == null)
        //         {
        //             return null;
        //         }
        //         foreach (var pc in product.ProductCategories)
        //         {
        //             if (pc.CategoryId == id
        //                && pc.ProductId == product.Id)
        //             {
        //                 guids.ToList().Remove();
        //             }
        //         }
        //     }
        // }
    }
}