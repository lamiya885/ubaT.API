using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ubaT.DTOs.Games;
using ubaT.DTOs.Words;
using ubaT.Entities;
using ubaT.Exceptions;
using ubaT.Services.Abstracts;

namespace ubaT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service,IMapper _mapper,IMemoryCache _cache) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> Create(GameCreateDto dto)
        {
            try
            {
                return Ok(await _service.CreateAsync(dto));

            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        message = bEx.ErrorMessage
                    });

                }
                else
                {
                    return BadRequest(new
                    {
                        message = ex.Message
                    });
                }
            }
        }
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Guid>> Edit(GameEditDto dto ,Guid id)
        {
            try
            {
            Guid Id= await _service.Edit(dto, id);
                return Ok(Id);

            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        message = bEx.ErrorMessage
                    });

                }
                else
                {
                    return BadRequest(new
                    {
                        message = ex.Message
                    });
                }
            }

        }
        [HttpOptions("[action]/{Id}")]
        public async Task Game(Guid Id)
        {
            
             WordForGameDto dto= await _service.Start(Id);
             _cache.Set(Id, dto);

        }
    }
}
