using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using ubaT.DAL;
using ubaT.DTOs.Languages;
using ubaT.Entities;
using ubaT.Exceptions;
using ubaT.Services.Abstracts;

namespace ubaT.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet("[action]")]
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

        [HttpGet("[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {
                return Ok(await _service.GetByCodeAsync(code));
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
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
        [HttpPut("[action]/{code}")]
        public async Task<IActionResult> Update(LanguageUpdateDto dto, string code)
            {
                    try
                    {

                        await _service.UpdateAsync(dto, code);
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
        [HttpDelete("[action]/{code}")]
         public async Task<IActionResult> Delete(string code)
            {
                    try
                    {
                        await _service.DeleteAsync(code);
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


