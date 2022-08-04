using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilaProcessamento.Api.Models;
using FilaProcessamento.Domain.Dtos.Result;
using Microsoft.AspNetCore.Mvc;

namespace FilaProcessamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilaController : ControllerBase
    {
        public Queue<MoedaModel> _moedaModelsQueue = new Queue<MoedaModel>();        
        public Queue<MoedaModel> MoedaModelsQueue
        {
            get { return _moedaModelsQueue; }
            set { _moedaModelsQueue = value; }
        }        

        [HttpPost("AddItemFila")]
        public async Task<IActionResult> AddItemFila([FromBody] MoedaModel moedaModel)
        {
            try
            {
                moedaModel.Validate();
                if (moedaModel.Invalid)
                    return BadRequest(new MessageDTO(false, moedaModel.Notifications));

                _moedaModelsQueue.Enqueue(moedaModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageDTO(false, ex.Message));
            }
        }

        [HttpGet("GetItemFila")]
        public async Task<IActionResult> GetItemFila()
        {
            try
            {
                return Ok(_moedaModelsQueue.Dequeue());
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageDTO(false, ex.Message));
            }
        }

        
        //private readonly Queue<MoedaModel> MoedaModelsQueue;
        //private Queue<MoedaModel> MoedaModelsQueue { get; set; }        
    }
}