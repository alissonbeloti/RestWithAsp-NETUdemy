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
        [HttpGet("sum/{firtNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firtNumber}/{secondNumber}")]
        public ActionResult<string> Subtraction(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firtNumber}/{secondNumber}")]
        public ActionResult<string> Division(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firtNumber}/{secondNumber}")]
        public ActionResult<string> Multiplication(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("avg/{firtNumber}/{secondNumber}")]
        public ActionResult<string> Average(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) * ConvertToDecimal(secondNumber) / 2;
                return Ok(sum.ToString());
            }
            return Ok("Invalid Input");
        }

        [HttpGet("square-Root/{firtNumber}")]
        public ActionResult<string> SquareRoot(string firtNumber)
        {
            if (IsNumeric(firtNumber))
            {
                var square = Math.Sqrt((double)ConvertToDecimal(firtNumber));
                return Ok(square.ToString());
            }
            return Ok("Invalid Input");
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
