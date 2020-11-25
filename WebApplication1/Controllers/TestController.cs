using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public TestController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ProductResponse>> GetAsync(Guid id)
        {
            var allowedCategories = await _productRepository.GetByIdAsync(id);

            return Ok(allowedCategories);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductPayload productPayload)
        {
            var product = new Product
            {
                Name = productPayload.Name
            };

            await _productRepository.CreateAsync(product);

            await _productRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
