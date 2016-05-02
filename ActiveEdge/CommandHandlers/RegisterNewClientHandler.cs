using ActiveEdge.Database;
using ActiveEdge.Models.Clients.Command;
using AutoMapper;
using MediatR;

namespace ActiveEdge.CommandHandlers
{
  public class RegisterNewClientHandler: INotificationHandler<RegisterNewClient>
  {
    private readonly IApplicationDbContext _database;
    private readonly IMapper _mapper;

    public RegisterNewClientHandler(IApplicationDbContext database, IMapper mapper)
    {
      _database = database;
      _mapper = mapper;
    }
    
    /// <summary>
    /// Handles a notification
    /// </summary>
    /// <param name="notification">The notification message</param>
    public void Handle(RegisterNewClient notification)
    {
      var customerDomain = _mapper.Map<RegisterNewClient, Domain.Client>(notification);

      _database.Clients.Add(customerDomain);

      _database.SaveChanges();
    }
  }
}