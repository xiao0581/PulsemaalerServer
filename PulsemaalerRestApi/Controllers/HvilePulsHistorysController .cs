using Microsoft.AspNetCore.Mvc;
using PulsemaalerRestApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PulsemaalerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HvilePulsHistorysController : ControllerBase
    {
        private readonly PulsHistoryRepository _repository;

        public HvilePulsHistorysController(PulsHistoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PulsHistory>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PulsHistory>> GetById(int personId)
        {
            var records = _repository.GetByPersonId(personId);
            if (records == null || !records.Any())
            {
                return NotFound($"No history found for person ID {personId}.");
            }
            return Ok(records);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PulsHistory>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PulsHistory>> GetHvilePulsHistories()
        {
            IEnumerable<PulsHistory> personList = _repository.GetAll();
            if (!personList.Any())
            {
                return NotFound("No pulse histories found.");
            }
            return Ok(personList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PulsHistory))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PulsHistory> AddHvilePulsHistory(PulsHistory history)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PulsHistory createdHistory = _repository.Add(history);
            if (createdHistory == null)
            {
                return StatusCode(500, "An error occurred while creating the history record.");
            }

            return CreatedAtAction(nameof(GetById), new { personId = history.PersonId }, history);
        }

        [HttpPut("{historyId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateHvilePulsHistory(int historyId, PulsHistory history)
        {
            if (historyId != history.HistoryId)
            {
                return BadRequest("Mismatch between the URL history ID and the body history ID.");
            }

            try
            {
                var updatedHistory = _repository.Update(history);
                if (updatedHistory == null)
                {
                    return NotFound($"No history found with ID {historyId}.");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the history.");
            }
        }

        [HttpDelete("{historyId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteHvilePulsHistory(int historyId)
        {
            var history = _repository.Delete(historyId);
            if (history == null)
            {
                return NotFound($"No history found with ID {historyId}.");
            }
            return NoContent();
        }
    }
}
