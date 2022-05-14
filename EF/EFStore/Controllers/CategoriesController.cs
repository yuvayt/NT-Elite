using System;
using System.Collections.Generic;
using EFStore.Models.DTO;
using EFStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpPost("/create-category")]
        public CategoryDTO Create([FromBody] CategoryDTO newCategory)
        {
            return _service.Add(newCategory);
        }

        [HttpGet("/get-category")]
        public CategoryDTO Get(Guid id)
        {
            return _service.GetById(id);
        }

        [HttpGet("/get-all-categories")]
        public IEnumerable<CategoryDTO> People([FromQuery] FilterParameters parameters)
        {
            return _service.GetAll(parameters);
        }

        [HttpDelete("/delete-category")]
        public bool Delete(Guid id)
        {
            return _service.Remove(id);
        }

        [HttpPut("/update-category")]
        public CategoryDTO Update(CategoryDTO updateCategory)
        {
            return _service.Update(updateCategory);
        }
    }
}