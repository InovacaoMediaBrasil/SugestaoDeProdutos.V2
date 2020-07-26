using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SugestaoDeProdutos.Controllers
{
    [Produces("application/json")]
    [Route("")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult PostSuggestionAsync()
        {
            return Ok();
        }
    }
}
