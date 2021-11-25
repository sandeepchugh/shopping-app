using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models.Dto;
using ProductApi.Repositories;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<object> Get()
    {
        var response = new ResponseDto();
        try
        {
            response.Result = await _productRepository.GetProducts();
        }
        catch(Exception ex)
        {
            response.IsSuccess = false;
            response.ErrorMessages = new List<string>{ ex.ToString() };
        }
        return response;
    }
    
    [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            var response = new ResponseDto();
            try
            {
                response.Result = await _productRepository.GetProductById(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>{ ex.ToString() };
            }
            return response;
        }


        [HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            var response = new ResponseDto();
            try
            {
                response.Result = await _productRepository.CreateOrUpdateProduct(productDto);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>{ ex.ToString() };
            }
            return response;
        }


        [HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            var response = new ResponseDto();
            try
            {
                response.Result = await _productRepository.CreateOrUpdateProduct(productDto);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>{ ex.ToString() };
            }
            return response;
        }

        [HttpDelete]
        [Authorize(Roles ="Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            var response = new ResponseDto();
            try
            {
                response.Result = await _productRepository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>{ ex.ToString() };
            }
            return response;
        }
}