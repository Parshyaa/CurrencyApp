using CurrencyConverter.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private readonly ICurrency _CurrencyBll;

        public CurrencyController(ICurrency currency)
        {
            _CurrencyBll = currency;
        }

        [HttpGet("getRate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var result = _CurrencyBll.GetRate("USD", "EUR");

            return Ok(result);
        }
    }
}

