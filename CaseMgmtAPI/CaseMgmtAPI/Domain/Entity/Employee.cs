using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Domain.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}
