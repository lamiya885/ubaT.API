using Microsoft.AspNetCore.Mvc;
using ubaT.DTOs.Languages;
using ubaT.Services.Abstracts;

namespace ubaT.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController (ILanguageService _service): Controller
    {
        public async Task<IActionResult> Get()
        {

            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create (LanguageCreateDto dto)
        {
            await _service.CreatedAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok();
        }
    }
}
