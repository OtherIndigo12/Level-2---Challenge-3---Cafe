using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _services;

        public CategoriesController(ICategoriesServices services)
        {
            _services = services;
        }

        [HttpGet]

        public async Task<ActionResult<List<ResponseCategoriesDTO>>> GetAll()
        {
            return Ok( await _services.GetAllAsync());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<ResponseCategoriesDTO>> GetById(int id)
        {
            ResponseCategoriesDTO? categories = await _services.GetByIdAsync(id);

            if(categories is null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpPost("AddCategories")]

        public async Task<ActionResult<ResponseCategoriesDTO>> AddMenu([FromBody] CreateCategoriesDTO dto)
        {
            ResponseCategoriesDTO categories = await _services.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new {id = categories.Id}, categories);
        }

        [HttpPut("Update/{id}")]

        public async Task<ActionResult<ResponseCategoriesDTO>> Update(int id, [FromBody] UpdateCategoriesDTO dto)
        {
            ResponseCategoriesDTO? categories = await _services.UpdateAsync(id, dto);

            if (categories is null)
            {
                return NotFound(); 
            }

            return Ok(categories);
        }
    }
}