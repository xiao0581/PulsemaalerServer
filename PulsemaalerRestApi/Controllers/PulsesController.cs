using Microsoft.AspNetCore.Mvc;
using PulsemaalerRestApi.Model;
using PulsemaalerRestApi.Repositories;

namespace PulsemaalerRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Puls : ControllerBase
    {
        private readonly PulsRepo _pulsRepo = new();

        [HttpGet]
        public IEnumerable<Pulse> Get()
        {
            return _pulsRepo.GetAll();
        }

        [HttpGet("{id}")]
        public Pulse GetBy(int id)
        {
            return _pulsRepo.GetById(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pulse> Post([FromBody]Pulse puls) 
        {
            try
            {
                Pulse createdPuls = _pulsRepo.AddPuls(puls);
                return Created("/" + createdPuls.id, createdPuls);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}