using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using FilaProcessamento.Api.Models;
using FilaProcessamento.Domain.Dtos.Result;
using Microsoft.AspNetCore.Mvc;

namespace FilaProcessamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilaController : ControllerBase
    {
        private static ConcurrentStack<MoedaModel> _moedaModelsQueue;
        public static ConcurrentStack<MoedaModel> MoedaModelsQueue
        {
            get
            {
                if (_moedaModelsQueue == null)
                    _moedaModelsQueue = new ConcurrentStack<MoedaModel>();
                return _moedaModelsQueue;
            }
        }

        [HttpPost("AddItemFila")]
        public IActionResult AddItemFila([FromBody] ICollection<MoedaModel> moedaModel)
        {
            try
            {
                foreach (var moeda in moedaModel)
                {
                    moeda.Validate();
                    if (moeda.Invalid)
                        return BadRequest(new MessageDTO(false, moeda.Notifications));
                                        
                    MoedaModelsQueue.Push(moeda);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageDTO(false, ex.Message));
            }
        }

        [HttpGet("GetItemFila")]
        public IActionResult GetItemFila()
        {
            try
            {
                if (MoedaModelsQueue.TryPop(out MoedaModel ultimoItem))
                    return Ok(ultimoItem);

                return BadRequest(new MessageDTO(false, "Não existe objeto a ser retornado"));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageDTO(false, ex.Message));
            }
        }
    }
}