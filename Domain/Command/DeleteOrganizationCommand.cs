namespace Domain.Command
{
    public class DeleteOrganizationCommand: ICommand
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public DeleteOrganizationCommand(int organizationId)
        {
            OrganizationId = organizationId;
        }

        public int OrganizationId { get; }
    }
}
