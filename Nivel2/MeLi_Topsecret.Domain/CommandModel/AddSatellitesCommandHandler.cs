using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MeLi_Topsecret.Domain.Dtos;
using MeLi_Topsecret.Domain.Repository;

namespace MeLi_Topsecret.Domain.CommandModel
{
    public class AddSatellitesCommandHandler : IRequestHandler<AddSatellitesCommand, MessageDto>
    {
        public AddSatellitesCommandHandler(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        private readonly IMediator Mediator;

        public async Task<MessageDto> Handle(AddSatellitesCommand command, CancellationToken cancellationToken)
        {
            var message = new MessageDto();
            var repository = new AlianzaRebeldeRepository();

            if (command.Satellites.Length == 3)
            {
                var position = new PositionDto();
                position.x = repository.CalculateX(command.Satellites[0].Distance, command.Satellites[1].Distance, command.Satellites[2].Distance);
                position.y = repository.CalculateY(command.Satellites[0].Distance, command.Satellites[1].Distance, command.Satellites[2].Distance);
                message.Position = position;

                message.Message = repository.CreateMessage(command.Satellites);
            }


            
            
            return message;
        }

    }
}
