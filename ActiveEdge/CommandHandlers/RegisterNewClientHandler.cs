using ActiveEdge.Database;
using ActiveEdge.Models;
using AutoMapper;
using Domain.Model;
using MediatR;

namespace ActiveEdge.CommandHandlers
{
  public class RegisterNewClientHandler: INotificationHandler<ClientModel>
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
    public void Handle(ClientModel notification)
    {
      var customerDomain = _mapper.Map<ClientModel, Client>(notification);

      _database.Clients.Add(customerDomain);

      _database.SaveChanges();
    }
  }
}