using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Read.Model.Users
{
    public class UserModel
    {
        [UIHint("StandardFormTextBox")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [UIHint("StandardFormTextBox")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [UIHint("StandardFormTextBox")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [UIHint("StandardFormTextBox")]
        public string PhoneNumber { get; set; }

        [DisplayName("Is Administrator")]
        [UIHint("StandardFormCheckBox")]
        public bool IsAdministrator { get; set; }
    }
}