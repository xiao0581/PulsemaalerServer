using Microsoft.AspNetCore.Mvc;
using PulsemaalerRestApi.Model;


namespace PulsemaalerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Person> Post([FromBody] Person person) 
        {
            try
            {
                Person person1 = _pulsRepo.Add(person);
                return Created("/" + person1.Name, person1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{name}")]
        public ActionResult<Person> Put(String name, [FromBody] Person person)
        {
                Person? update = _pulsRepo.update(name, person);
                if (update == null) return NotFound();
                else return Ok(update);
           
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{name}")]
        public ActionResult<Person> Delete(String name)
        {
            Person? deletedPerson = _pulsRepo.Delete(name);
            if (deletedPerson == null) return NotFound();
            else return Ok(deletedPerson);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{name}")]
        public ActionResult<Person> Get(String name)
        {
            Person? person = _pulsRepo.GetbyName(name);
            if (person == null)
            {
                return NotFound("No such class, name: \"" + name);
            }
            else
            {
                return Ok(person);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{name}")]
        public ActionResult<Person> Patch(String name, [FromBody] Person person)
        {
            Person? update = _pulsRepo.PatchUpdate(name, person);
            if (update == null) return NotFound();
            else return Ok(update);

        }
    }
}