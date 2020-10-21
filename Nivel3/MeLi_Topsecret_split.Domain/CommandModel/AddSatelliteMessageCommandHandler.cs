using System;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MeLi_Topsecret_split.Domain.Dtos;
using MeLi_Topsecret_split.Domain.Repository;

namespace MeLi_Topsecret_split.Domain.CommandModel
{
    public class AddSatelliteMessageCommandHandler : IRequestHandler<AddSatelliteMessageCommand, ResponseMessageDto>
    {
        public AddSatelliteMessageCommandHandler(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        private readonly IMediator Mediator;

        public async Task<ResponseMessageDto> Handle(AddSatelliteMessageCommand command, CancellationToken cancellationToken)
        {
            if (!command.ValidateSatelliteName(command.satellite_name))
            {
                return new ResponseMessageDto(false, "Satelite desconocido", new MessageDto());
            }

            if (command.message.Count > 5)
            {
                return new ResponseMessageDto(false, "El mensaje solo debe contener 5 palabras", new MessageDto());
            }

            //Agregar consulta a base de datos en memoria para guardar el objeto

            return new ResponseMessageDto(true, "", new MessageDto());
        }


    }
}
