using Microsoft.AspNetCore.Mvc;
using PulsemaalerRestApi.Model;


namespace PulsemaalerRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PulsesController : ControllerBase
    {
        private readonly PersonRepository _pulsRepo;
        public PulsesController(PersonRepository pulsRepo)
        {
            _pulsRepo = pulsRepo;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            try
            {
                IEnumerable<Person> personList = _pulsRepo.GetAll();

                if (!personList.Any())
                {
                    return NotFound("No persons found.");
                }

                return Ok(personList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Person> Post([FromBody] Person person) 
        {
            try
            {
                Person person1 = _pulsRepo.Add(person);
                return Created("/" + person1.Id, person1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, [FromBody] Person person)
        {
                Person? update = _pulsRepo.update(id, person);
                if (update == null) return NotFound();
                else return Ok(update);
           
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(int id)
        {
            Person? deletedPerson = _pulsRepo.Delete(id);
            if (deletedPerson == null) return NotFound();
            else return Ok(deletedPerson);
        }
    }
}