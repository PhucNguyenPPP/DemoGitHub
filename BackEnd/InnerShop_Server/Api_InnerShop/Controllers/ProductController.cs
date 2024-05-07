using BLL.Interface;
using DAL.Data;
using DAL.Entities.Parameters;
using DAL.Repositories.IRepositories;
using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_InnerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly InnerContext _innerContext;

        public ProductController(IProductService productService, InnerContext innerContext) 
        {
            _productService = productService;
            _innerContext = innerContext;
        }
        
        [HttpGet]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> GetAllProduct([FromQuery] ProductParameters productParameters)
        {
            var result = await _productService.GetAllProduct(productParameters);
            //var result = _innerContext.Products.ToList();
            if (result != null)
            {
                var response = new ResponseDTO("Succesffully", 200, true, result);
                return Ok(response);
            }
            return BadRequest(new ResponseDTO("Failed", 400, false));
        }
    }
}
