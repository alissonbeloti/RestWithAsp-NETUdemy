using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;

namespace RestWithAsp_NETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookBusiness bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            this.bookBusiness = bookBusiness;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(bookBusiness.FindAll());
            //return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = this.bookBusiness.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
            //return Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] BookVO value)
        {
            var book = this.bookBusiness.Create(value);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] BookVO value)
        {
            var book = this.bookBusiness.Update(value);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            bookBusiness.Delete(id);
            return NoContent();
        }
    }
}