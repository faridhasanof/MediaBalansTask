using Microsoft.AspNetCore.Mvc;
using System;
using TaskCoreAPI.Business.Abstract;
using TaskCoreAPI.Entity.Models;
using TaskCoreAPI.WebUI.Response;

namespace TaskCoreAPI.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                _productService.Create(product);
                Responses response = new Responses() { Result = null, Message = "Success" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                _categoryService.Create(category);
                Responses response = new Responses() { Result = null, Message = "Success" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var result = _productService.GetAll();
                Responses response = new Responses();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Error occured!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";
                return Ok(response);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var result = _categoryService.GetAll();
                Responses response = new Responses();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Error occured!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";
                return Ok(response);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet()]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var result = _productService.GetById(id);
                Responses response = new Responses();
                if (result == null)
                {
                    response.Result = null;
                    response.Message = "Error occured!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }
        [HttpGet()]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var result = _categoryService.GetById(id);
                Responses response = new Responses();
                if (result == null)
                {
                    response.Result = null;
                    response.Message = "Error occured!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                _productService.Update(product);
                Responses response = new Responses() { Result = null, Message = "Success" };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                _categoryService.Update(category);
                Responses response = new Responses() { Result = null, Message = "Success" };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.Delete(id);
                Responses response = new Responses() { Result = null, Message = "Success" };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryService.Delete(id);
                Responses response = new Responses() { Result = null, Message = "Success" };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }


        }
    }
}
