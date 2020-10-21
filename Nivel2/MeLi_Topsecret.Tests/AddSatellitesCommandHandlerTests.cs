using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MeLi_Topsecret.Domain.CommandModel;
using MeLi_Topsecret.Domain.Dtos;
using MeLi_Topsecret.Domain.Repository;
using Moq;
using Xunit;

namespace MeLi_Topsecret.Tests
{
    public class AddSatellitesCommandHandlerTests
    {
        [Fact]
        public async Task Handler_ValidEntity_ReturnsMessageDto()
        {
            //Arrange
            var command = new Mock<AddSatellitesCommand>();
            var repository = new Mock<AlianzaRebeldeRepository>();
            var mediator = new Mock<IMediator>();

            var satelliteKenobiMessage = new SatelliteMessage()
            {
                Name = "kenobi",
                Distance = 100.0,
                Message = new List<string>(){"este", "", "", "mensaje", ""}
            };
            var satelliteSkywalkerMessage = new SatelliteMessage()
            {
                Name = "skywalker",
                Distance = 115.5,
                Message = new List<string>() { "", "es", "", "", "secreto" }
            };

            var satelliteSatoMessage = new SatelliteMessage()
            {
                Name = "sato",
                Distance = 142.7,
                Message = new List<string>() { "este", "", "un", "", "" }
            };

            command.Object.Satellites = new SatelliteMessage[3];
            command.Object.Satellites[0] = satelliteKenobiMessage;
            command.Object.Satellites[1] = satelliteSkywalkerMessage;
            command.Object.Satellites[2] = satelliteSatoMessage;

            var handler = new AddSatellitesCommandHandler(mediator.Object);

            //Act
            var response = await handler.Handle(command.Object, CancellationToken.None);

            //Assert
            command.VerifyAll();
            repository.VerifyAll();

            //Verify the output
            Assert.NotNull(response);
            Assert.IsType<MessageDto>(response);

            Assert.NotEmpty(response.Message);
        }

        [Fact]
        public async Task Handler_InvalidValidEntity_ReturnsEmptyMessageDto()
        {
            //Arrange
            var command = new Mock<AddSatellitesCommand>();
            var repository = new Mock<AlianzaRebeldeRepository>();
            var mediator = new Mock<IMediator>();

            var satelliteKenobiMessage = new SatelliteMessage()
            {
                Name = "kenobi",
                Distance = 100.0,
                Message = new List<string>() { "este", "", "", "mensaje", "" }
            };
            var satelliteSkywalkerMessage = new SatelliteMessage()
            {
                Name = "skywalker",
                Distance = 115.5,
                Message = new List<string>()
            };

            var satelliteSatoMessage = new SatelliteMessage()
            {
                Name = "sato",
                Distance = 142.7,
                Message = new List<string>() { "este", "", "un", "", "" }
            };

            command.Object.Satellites = new SatelliteMessage[3];
            command.Object.Satellites[0] = satelliteKenobiMessage;
            command.Object.Satellites[1] = satelliteSkywalkerMessage;
            command.Object.Satellites[2] = satelliteSatoMessage;

            var handler = new AddSatellitesCommandHandler(mediator.Object);

            //Act
            var response = await handler.Handle(command.Object, CancellationToken.None);

            //Assert
            command.VerifyAll();
            repository.VerifyAll();

            //Verify the output
            Assert.NotNull(response);
            Assert.IsType<MessageDto>(response);

            Assert.Empty(response.Message);
        }
    }
}
