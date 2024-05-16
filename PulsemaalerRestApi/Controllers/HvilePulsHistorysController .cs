using Microsoft.AspNetCore.Mvc;
using PulsemaalerRestApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PulsemaalerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HvilePulsHistorysController : ControllerBase
    {
        private readonly HvilePulsHistoryRepository _repository;

        public HvilePulsHistorysController(HvilePulsHistoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{personId}")]
        public ActionResult<IEnumerable<HvilePulsHistory>> GetById(int personId)
        {
            var records = _repository.GetByPersonId(personId);
            return Ok(records);
        }
        [HttpGet]
        public ActionResult<IEnumerable<HvilePulsHistory>> GetHvilePulsHistories()
        {
            IEnumerable<HvilePulsHistory> personList = _repository.GetAll();
            return Ok(personList);
        }

        [HttpPost]
        public ActionResult<HvilePulsHistory> AddHvilePulsHistory(HvilePulsHistory history)
        {
            _repository.Add(history);
            return CreatedAtAction(nameof(GetHvilePulsHistories), new { personId = history.PersonId }, history);
        }

        [HttpPut("{historyId}")]
        public IActionResult UpdateHvilePulsHistory(int historyId, HvilePulsHistory history)
        {
            if (historyId != history.HistoryId)
            {
                return BadRequest();
            }

            _repository.Update(history);
            return NoContent();
        }

        [HttpDelete("{historyId}")]
        public IActionResult DeleteHvilePulsHistory(int historyId)
        {
            _repository.Delete(historyId);
            return NoContent();
        }
    }
}
