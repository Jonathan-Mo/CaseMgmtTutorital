using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Features.Reporters.DTO
{
    public class ReporterDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
