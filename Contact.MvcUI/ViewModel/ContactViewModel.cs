using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contact.MvcUI.ViewModel
{
    public class ContactViewModel
    {
        [DisplayName("CONTACT ID")]
        public int ContactId { get; set; }

        [DisplayName("FIRST NAME")]
        [Required(ErrorMessage = "Please enter the First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [DisplayName("LAST NAME")]
        [Required(ErrorMessage = "Please enter the Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [DisplayName("PHONE NUMBER")]
        [Required(ErrorMessage = "please enter the desired Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("EMAIL")]
        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("STATUS")]
        [Required(ErrorMessage = "Status Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(8,MinimumLength =6,ErrorMessage =" Status length must in between 6 to 8 charachter ")]
        public string Status { get; set; }

        public status contactStatus { get; set; } 

    }
    public enum status
    {
        Active = 1,
        Inactive = 2
    }

}