using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Domain.Entity
{
    public class Reporter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide your first name.")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Please provide your last name.")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide your email address.")]
        [StringLength(320)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide your phone number.")]
        [StringLength(10)]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
    }
}
