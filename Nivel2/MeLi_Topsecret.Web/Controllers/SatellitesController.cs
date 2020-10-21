using System.Threading.Tasks;
using MediatR;
using MeLi_Topsecret.Domain;
using MeLi_Topsecret.Domain.CommandModel;
using MeLi_Topsecret.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeLi_Topsecret.Controllers
{
    [Produces("application/json")]
    [Route("/topsecret/")]
    [ApiController]
    public class SatellitesController : ControllerBase
    {
        public SatellitesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        private IMediator Mediator { get; }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageDto>> PostSatellites([FromBody] AddSatellitesCommand addCommand)
        {
            var response = await Mediator.Send(addCommand);

            if (response?.Position == null || string.IsNullOrEmpty(response.Message))
            {
                return NotFound();
            }

            return response;
        }
    }
}
