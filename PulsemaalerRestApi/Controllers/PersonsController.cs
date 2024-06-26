﻿using Microsoft.AspNetCore.Mvc;
using PulsemaalerRestApi.Model;


namespace PulsemaalerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonRepository _personsRepo;
        public PersonsController(PersonRepository personsRepo)
        {
            _personsRepo = personsRepo;
        }


        /// <summary>
        /// This method gets all the persons from the database
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            try
            {
                IEnumerable<Person> personList = _personsRepo.GetAll();

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

        /// <summary>
        /// This method adds a person to the database
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Person> Post([FromBody] Person person) 
        {
            try
            {
                Person person1 = _personsRepo.Add(person);
                return Created("/" + person1.Name, person1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This method updates a person in the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{name}")]
        public ActionResult<Person> Put(String name, [FromBody] Person person)
        {
                Person? update = _personsRepo.update(name, person);
                if (update == null) return NotFound();
                else return Ok(update);
           
        }


        /// <summary>
        /// This method deletes a person from the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{name}")]
        public ActionResult<Person> Delete(String name)
        {
            Person? deletedPerson = _personsRepo.Delete(name);
            if (deletedPerson == null) return NotFound();
            else return Ok(deletedPerson);
        }
        /// <summary>
        /// This method gets a person from the database by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{name}")]
        public ActionResult<Person> Get(String name)
        {
            Person? person = _personsRepo.GetbyName(name);
            if (person == null)
            {
                return NotFound("No such class, name: \"" + name);
            }
            else
            {
                return Ok(person);
            }
        }



        /// <summary>
        /// This method can update only one or more of several properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{name}")]
        public ActionResult<Person> Patch(String name, [FromBody] Person person)
        {
            Person? update = _personsRepo.PatchUpdate(name, person);
            if (update == null) return NotFound();
            else return Ok(update);

        }
        [HttpGet("{name}/histories")]
        public ActionResult<Person> GetPersonWithHistories(string name)
        {
            var person = _personsRepo.GetPersonWithHistories(name);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}