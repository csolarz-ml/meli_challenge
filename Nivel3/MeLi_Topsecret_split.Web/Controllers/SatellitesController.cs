using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MeLi_Topsecret_split.Domain;
using MeLi_Topsecret_split.Domain.CommandModel;
using MeLi_Topsecret_split.Domain.Dtos;
using MeLi_Topsecret_split.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeLi_Topsecret_split.Web.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class SatellitesController : ControllerBase
    {
        public SatellitesController( IMediator mediator)
        {
            Mediator = mediator;
        }

        private IMediator Mediator { get; }

        [HttpGet]
        public async Task<ActionResult<MessageDto>> GetAllMessage()
        {
            //var response = await Mediator.Send(new MessageQuery());
            return new MessageDto();
        }


        [HttpPost]
        [Route("topsecret_split/{satellite_name}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseMessageDto>> PostSatelliteMessage([FromBody] AddSatelliteMessageCommand addCommand)
        {
            var response = await Mediator.Send(addCommand);

            if (!response.IsValid)
            {
                return NotFound();
            }

            return response;
        }
    }
}
