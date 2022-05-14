using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFStore.Models.DTO;
using EFStore.Models.Entities;

namespace EFStore.Extensions
{
    public static class CategoryExtension
    {
        public static Category ToEntity(this CategoryDTO dto)
        {
            var entity = new Category
            {
                ProductCategories = new List<ProductCategory>()
            };

            entity = MappingProperties(entity, dto);

            return entity;
        }
        public static CategoryDTO ToDto(this Category entity)
        {
            return new CategoryDTO
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        public static Category MappingProperties(this Category entity, CategoryDTO dto)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;

            foreach (var id in dto.ProductIds)
            {
                entity.ProductCategories.Add(new ProductCategory
                {
                    ProductId = id,
                });
            }

            return entity;
        }
    }
}