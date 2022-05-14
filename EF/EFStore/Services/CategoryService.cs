using System;
using System.Collections.Generic;
using System.Linq;
using EFStore.Extensions;
using EFStore.Models.DTO;
using EFStore.Repositories.Interfaces;

namespace EFStore.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CategoryDTO Add(CategoryDTO dto)
        {
            if (dto == null)
            {
                return null;
            }
            var addingCategory = _unitOfWork.Categories.Add(dto.ToEntity());
            _unitOfWork.SaveChanges();

            return addingCategory.ToDto();
        }

        public IEnumerable<CategoryDTO> GetAll(FilterParameters parameters)
        {
            var categories = _unitOfWork.Categories.GetAll();
            var searchString = parameters.SearchString;
            var sortOrder = parameters.SortOrder;
            var pageSize = parameters.PageSize;
            var pageNumber = parameters.PageNumber;
            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(c => c.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(c => c.Name);
                    break;
                default:
                    categories = categories.OrderBy(c => c.Name);
                    break;
            }

            return categories
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .Select(x => x.ToDto());
        }

        public CategoryDTO GetById(Guid id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                return null;
            }

            return category.ToDto();
        }

        public bool Remove(Guid id)
        {
            var deleteCategory = _unitOfWork.Categories.GetById(id);
            if (deleteCategory == null)
            {
                return false;
            }
            _unitOfWork.Categories.Remove(deleteCategory);
            _unitOfWork.SaveChanges();

            return true;
        }

        public CategoryDTO Update(CategoryDTO dto)
        {
            var updateCategory = _unitOfWork.Categories.GetById(dto.Id);
            if (updateCategory == null)
            {
                return null;
            }

            updateCategory = updateCategory.MappingProperties(dto);

            _unitOfWork.SaveChanges();

            return updateCategory.ToDto();
        }
    }
}