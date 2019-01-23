using Microsoft.AspNetCore.Mvc;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Services;

namespace RestWithAsp_NETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService personService;

        public PersonsController(IPersonService personService)
        {
            this.personService = personService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = this.personService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            else {
                return Ok(person);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person value)
        {
            var person = this.personService.Create(value);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person value)
        {
            var person = this.personService.Update(value);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            personService.Delete(id);
            return NoContent();
        }
    }
}
