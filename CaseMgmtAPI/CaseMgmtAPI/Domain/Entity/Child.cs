using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Domain.Entity
{
    public class Child
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? StreetAddress { get; set; }
        [Required]
        public int City { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public string? ZipCode { get; set; }
        [Required]
        public string? Details { get; set; }
        public bool IsDeleted { get; set; }
    }
}
