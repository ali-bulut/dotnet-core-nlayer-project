using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleNLayerProject.API.DTOs;
using SampleNLayerProject.Core.Services;

namespace SampleNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        // it will fill by using dependency injection that is configured in startup.cs.
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
    }
}
