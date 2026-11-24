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
    public class ItemsController : ControllerBase
    {
        private readonly IItemsServices _services;

        public ItemsController(IItemsServices services)
        {
            _services = services;
        }

        [HttpGet]

        public async Task<ActionResult<List<ResponseItemsDTO>>> GetAll()
        {
            return Ok( await _services.GetAllAsync());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<ResponseItemsDTO>> GetById(int id)
        {
            ResponseItemsDTO? items = await _services.GetByIdAsync(id);

            if(items is null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        [HttpPost("AddItems")]

        public async Task<ActionResult<ResponseItemsDTO>> AddMenu([FromBody] CreateItemsDTO dto)
        {
            ResponseItemsDTO items = await _services.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new {id = items.Id}, items);
        }

        [HttpPut("Update/{id}")]

        public async Task<ActionResult<ResponseItemsDTO>> Update(int id, [FromBody] UpdateItemsDTO dto)
        {
            ResponseItemsDTO? items = await _services.UpdateAsync(id, dto);

            if (items is null)
            {
                return NotFound(); 
            }

            return Ok(items);
        }
    }
}