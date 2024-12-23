using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ubaT.DAL;
using ubaT.DTOs.BannedWords;
using ubaT.Exceptions;
using ubaT.Services.Abstracts;

namespace ubaT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController (IMapper _mapper,IBannedWordService _service): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                if (ex is IBaseException Bex)
                {
                    return StatusCode(Bex.StatusCode, new
                    {
                        Mesage = Bex.ErrorMessage
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
     
        [HttpGet("{text}")]
        public async Task<IActionResult> GetByText(string text)
        {
            try
            {
                await _service.GetByTextAsync(text);
                    return Ok();
            }
            catch(Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        Message = bEx.ErrorMessage

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

        [HttpPost]
        public async Task<IActionResult> Create (BannedWordCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
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
                        Massage = ex.Message

                    });
                }
            }
        }
        [HttpPost("{text}")]
        public async Task<IActionResult> Update(BannedWordUpdateDto dto,string text)
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
        [HttpDelete("{text}")]
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
