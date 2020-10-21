using System.Collections.Generic;
using MediatR;
using MeLi_Topsecret.Domain.Dtos;

namespace MeLi_Topsecret.Domain.CommandModel
{
    public class AddSatellitesCommand : IRequest<MessageDto>
    {
        public SatelliteMessage[] Satellites { get; set; }
        }

    public class SatelliteMessage
    {
        public string Name { get; set; }
        public double Distance { get; set; }
        public List<string> Message { get; set; }
    }
}
