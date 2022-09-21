using System.ComponentModel.DataAnnotations;

namespace CaseMgmtPortal.Models
{
    public class Reporter
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
    }
}
