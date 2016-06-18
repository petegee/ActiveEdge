using Shared;

namespace Domain.Command.Session
{
    public class DeleteSessionCommand : ICommand
    {
        public int Id { get; set; }
    }
}