using Microsoft.AspNetCore.Mvc;
using OhmValueCalculator.Domain;
using OhmValueCalculator.Services;

namespace OhmValueCalculator.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private IOhmValueCalculator _ohmValueCalculator;

        public CalculatorController(IOhmValueCalculator ohmValueCalculator)
        {
            _ohmValueCalculator = ohmValueCalculator;
        }

        [HttpGet("bandAColor/{bandAColor}/bandBColor/{bandBColor}/bandCColor/{bandCColor}/bandDColor/{bandDColor}")]
        public IActionResult Get(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            OhmValue value = _ohmValueCalculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
            
            if (value == null)
            {
                return BadRequest();
            }

            return Ok(value);
        }
    }
}
