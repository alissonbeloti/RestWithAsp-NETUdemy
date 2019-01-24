using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Tapioca.HATEOAS;


namespace RestWithAsp_NETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness loginBusines;

        public LoginController(ILoginBusiness personBusiness)
        {
            this.loginBusines = personBusiness;
        }
        
        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse((201), Type = typeof(User))]
        [SwaggerResponse((400))]
        [SwaggerResponse((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null) return BadRequest();
            var user = this.loginBusines.FindByLogin(value.Login);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
