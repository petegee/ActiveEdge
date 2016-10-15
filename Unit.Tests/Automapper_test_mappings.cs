using ActiveEdge.Infrastructure.Mapping;
using ActiveEdge.Read.Model;
using ActiveEdge.Read.Model.Client;
using AutoMapper;
using Domain.Command.Client;
using Xunit;

namespace Unit.Tests
{
    public class Automapper_test_mappings
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public Automapper_test_mappings()
        {
            var mapperConfig = AutoMapperConfiguration.Create();

            _mapper = mapperConfig.CreateMapper();
        }

        private readonly IMapper _mapper;

        [Fact]
        public void AssertConfigurationIsValid()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void Test_Name()
        {
            //Arrange
            var client = new ClientModel
            {
                FirstName = "Stuart",
                ContraIndicationsIsPregnant = true
            };

            var command = _mapper.Map<ClientModel, RegisterNewClient>(client);

            // Assert
            //command.FirstName.f.ShouldNotBeNull();

            //domainClient.ContraIndications.IsPregnant.ShouldBeTrue();
        }
    }
}