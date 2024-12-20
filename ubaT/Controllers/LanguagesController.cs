using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ubaT.DAL;
using ubaT.DTOs.Languages;
using ubaT.Services.Abstracts;

namespace ubaT.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController (ILanguageService _service,ubaTDbContext _context): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {

            return Ok(await _service.GetByCodeAsync(code));
        }


        [HttpPost]
        public async Task<IActionResult> Create (LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(LanguageUpdateDto dto,string code)
        {
            var entity = await _context.Languages.FindAsync(code);
            if (entity is null) return NotFound();
            await _service.UpdateAsync(dto,code);
            return Ok();
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var entity = await _context.Languages.FindAsync(code);
            if (entity is null) return NotFound();
            await _service.DeleteAsync(code);
            return Ok();
        }
    }
}
