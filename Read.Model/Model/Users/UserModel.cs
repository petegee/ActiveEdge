using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using roles = Domain.Context.Roles;
namespace ActiveEdge.Read.Model.Users
{
    public class UserModel
    {
        public string Id { get; set; }

        [UIHint("StandardFormTextBox")]
        [DisplayName("First Name")]

        public string FirstName { get; set; }
        [UIHint("StandardFormTextBox")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [UIHint("StandardFormTextBox")]
        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [UIHint("StandardFormTextBox")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [UIHint("StandardFormTextBox")]
        public string PhoneNumber { get; set; }

        [DisplayName("Is Administrator")]
        [UIHint("StandardFormCheckBox")]
        public bool IsAdministrator => Roles != null && Roles.Contains(roles.OrganizationAdministrator);

        public List<string> Roles { get; set; }
    }
}