using System.Collections.Generic;
using MediatR;

namespace MeLi_Topsecret_split.Domain.CommandModel
{
    public class AddSatelliteMessageCommand : IRequest<ResponseMessageDto>
    {
        public string satellite_name { get; set; }
        public double distance { get; set; }
        public List<string> message { get; set; }

        public bool ValidateSatelliteName(string satelliteName)
        {
            switch (satelliteName.ToLower())
            {
                case "kenobi":
                case "skywalker":
                case "sato":
                    return true;
                default:
                    return false;
            }
        }
    }

}
