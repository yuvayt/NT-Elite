using System;
using System.Collections.Generic;
using EFStore.Models.DTO;
using EFStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpPost("/create-product")]
        public ProductDTO Create([FromBody] ProductDTO newProduct)
        {
            return _service.Add(newProduct);
        }

        [HttpGet("/get-product")]
        public ProductDTO Get(Guid id)
        {
            return _service.GetById(id);
        }

        [HttpGet("/get-all-products")]
        public IEnumerable<ProductDTO> People([FromQuery] FilterParameters parameters)
        {
            return _service.GetAll(parameters);
        }

        [HttpDelete("/delete-product")]
        public bool Delete(Guid id)
        {
            return _service.Remove(id);
        }

        [HttpPut("/update-product")]
        public ProductDTO Update(ProductDTO updateProduct)
        {
            return _service.Update(updateProduct);
        }
    }
}