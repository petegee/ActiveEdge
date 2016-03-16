using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveEdge;
using ActiveEdge.Infrastructure.Mapping;
using ActiveEdge.Models;
using AutoMapper;
using Shouldly;
using Xunit;

namespace Unit.Tests
{

  public class Automapper_test_mappings
  {
    private IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Object"/> class.
    /// </summary>
    public Automapper_test_mappings()
    {
      var mapperConfig = AutoMapperConfiguration.Create();

      _mapper = mapperConfig.CreateMapper();

    }

    [Fact]
    public void AssertConfigurationIsValid()
    {
      Mapper.AssertConfigurationIsValid();
    }

    [Fact]
    public void Test_Name()
    {
      //Arrange
      var client = new Client {ContraIndicationsIsPregnant = true};

      var domainClient = _mapper.Map<Client, Domain.Client>(client);

      // Assert
      domainClient.ContraIndications.ShouldNotBeNull();

      domainClient.ContraIndications.IsPregnant.ShouldBeTrue();
    }
  }
    

    
}
