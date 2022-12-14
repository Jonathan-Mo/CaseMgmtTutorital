using System.ComponentModel.DataAnnotations;

namespace CaseMgmtPortal.Models
{
    public class Reporter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [StringLength(320)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
    }
}
