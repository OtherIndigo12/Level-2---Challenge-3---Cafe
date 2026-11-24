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
    public class MenuController : ControllerBase
    {
        private readonly IMenuServices _services;

        public MenuController(IMenuServices services)
        {
            _services = services;
        }

        [HttpGet]

        public async Task<ActionResult<List<ResponseMenuDTO>>> GetAll()
        {
            return Ok( await _services.GetAllAsync());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<ResponseMenuDTO>> GetById(int id)
        {
            ResponseMenuDTO? menu = await _services.GetByIdAsync(id);

            if(menu is null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPost("AddMenu")]

        public async Task<ActionResult<ResponseMenuDTO>> AddMenu([FromBody] CreateMenuDTO dto)
        {
            ResponseMenuDTO menu = await _services.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new {id = menu.Id}, menu);
        }

        [HttpPut("Update/{id}")]

        public async Task<ActionResult<ResponseMenuDTO>> Update(int id, [FromBody] UpdateMenuDTO dto)
        {
            ResponseMenuDTO? menu = await _services.UpdateAsync(id, dto);

            if (menu is null)
            {
                return NotFound(); 
            }

            return Ok(menu);
        }
    }
}