using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ubaT.DTOs.Words;
using ubaT.Exceptions;
using ubaT.Services.Abstracts;
using ubaT.Services.Implement;

namespace ubaT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController( IWordService _service) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("[action]/{text}")]
        public async Task<IActionResult> GetByText(string text)
        {
            return Ok(await _service.GetByTextAsync(text));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {
            foreach(var item in dto)
            {
                await _service.CreateAsync(item);
            }
            return Ok();
        }
        [HttpPost("[action]/{text}")]
        public async Task<IActionResult> Update(WordUpdateDto dto,string text)
        {
           
            try
            {

                await _service.UpdateAsync(dto, text);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException Bex)
                {
                    return StatusCode(Bex.StatusCode, new
                    {
                        Massage = Bex.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ex.Message
                    });
                }
            }
        }
        [HttpDelete("[action]/{text}")]
        public async Task<IActionResult> Delete(string text)
        { 
            try
            {
                await _service.DeleteAsync(text);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException Bex)
                {
                    return StatusCode(Bex.StatusCode, new
                    {
                        StatusCode = Bex.StatusCode,
                        Message = Bex.ErrorMessage
                    });

                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ex.Message
                    });
                }
            }
        }
    }
}
