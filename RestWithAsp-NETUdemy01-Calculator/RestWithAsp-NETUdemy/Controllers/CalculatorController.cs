using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAsp_NETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{firtNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) + ConvertToDecimal(firtNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal value;
            if (decimal.TryParse(number,out value))
            {
                return value;
            }
            return 0;

        }

        private bool IsNumeric(string strNumber)
        {
            decimal number;
            return decimal.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

        }
    }
}
