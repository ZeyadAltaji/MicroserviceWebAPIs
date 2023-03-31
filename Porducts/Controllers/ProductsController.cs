using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Appliction.DTOs;
using Product.Microservice.Appliction.UintOfWork;
using Product.Microservice.Domain;

namespace Porducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public ProductsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: api/<ProductsController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var Products = await uow.productsRepoistroy.GetAll();
            return Ok(Products);
        }

        // GET api/<ProductsController>/5
        [HttpPost("AddProducts")]
        public async Task<IActionResult> AddProducts(ProductsDtos productsDTOS)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var products = new Products
            {
                Name = productsDTOS.Name,
                Description = productsDTOS.Description,
                prince = productsDTOS.Price
            };
            uow.productsRepoistroy.AddProducts(products);
            await uow.productsRepoistroy.Save();
            return StatusCode(201);
        }

        // POST api/<ProductsController>
        [HttpPut("UpdatedProducts/{ID}")]
        public async Task<IActionResult> UpdatedProducts(int id, ProductsDtos ProductsDTOS)
        {
            if (id != ProductsDTOS.ID)
                return BadRequest("Update not allowd");
            var ProductsFormDB = await uow.productsRepoistroy.FindProducts(id);

            if (ProductsFormDB == null)
                return BadRequest("Update not allowd");

            var products = new Products
            {
                Id = ProductsDTOS.ID,
                Name = ProductsDTOS.Name,
                Description = ProductsDTOS.Description,
                prince = ProductsDTOS.Price
            };
            throw new Exception("Some Nnknown Error Occured");
            await uow.SaveAsycn();
            return this.StatusCode(200);
        }


        [HttpDelete("Delete/{byID}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            uow.productsRepoistroy.DeletedProducts(id);
            await uow.SaveAsycn();
            return Ok(id);
        }
    }
}
