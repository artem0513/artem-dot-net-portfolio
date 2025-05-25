using DotNetExample.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get/{categoryId}")]
        public async Task<IActionResult> Get([FromRoute] int categoryId, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetAsync(categoryId, cancellationToken));
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll([FromQuery] int categoryIds, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetAsync(categoryIds, cancellationToken));
        }

        [HttpDelete("admin/delete/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int categoryId, CancellationToken cancellationToken)
        {
            await _categoryService.DeleteAsync(categoryId, cancellationToken);
            return Ok();
        }
    }
}
