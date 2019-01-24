using Microsoft.AspNetCore.Mvc;
using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Services;

namespace RestWithAsp_NETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness personBusines;

        public PersonsController(IPersonBusiness personBusiness)
        {
            this.personBusines = personBusiness;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personBusines.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = this.personBusines.FindById(id);
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
        public IActionResult Post([FromBody] PersonVO value)
        {
            var person = this.personBusines.Create(value);
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
        public IActionResult Put([FromBody] PersonVO value)
        {
            var person = this.personBusines.Update(value);
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
            personBusines.Delete(id);
            return NoContent();
        }
    }
}
