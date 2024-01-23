using CrudExample.Data;
using CrudExample.Models;
using CrudExample.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private ProjectContext _context;
        public ParentController(ProjectContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var parent = await _context.Parents.ToListAsync();
            if (parent == null)
            {
                return BadRequest("Not Found!");
            }
            return Ok(parent);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var parent = await _context.Parents.FirstOrDefaultAsync(x => x.Id == id);
            if (parent == null)
            {
                return BadRequest("Not Found!");
            }
            return Ok(parent);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParentDto parentDto)
        {
            await _context.Parents.AddAsync(new Parent
            {
                Name = parentDto.Name,
                Address = parentDto.Address,
                PhoneNumber = parentDto.PhoneNumber,
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Parent parent)
        {
            var foundParent = await _context.Parents.FirstOrDefaultAsync(x => x.Id == parent.Id);
            if (foundParent == null)
            {
                return BadRequest("Not Found!");
            }
            foundParent.Name = parent.Name;
            foundParent.PhoneNumber = parent.PhoneNumber;
            foundParent.Address = parent.Address;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedParent = await _context.Parents.FirstOrDefaultAsync(x => x.Id == id);
            if (deletedParent == null)
            {
                return BadRequest("Not Found!");
            }
            _context.Remove(deletedParent);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
