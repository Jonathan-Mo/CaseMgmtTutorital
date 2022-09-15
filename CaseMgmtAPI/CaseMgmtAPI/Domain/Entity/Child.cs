using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Domain.Entity
{
    public class Child
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        [Required]
        public int City { get; set; }
        [Required]
        public int State { get; set; }
        public string? ZipCode { get; set; }
        public string? Details { get; set; }
        public bool IsDeleted { get; set; }
    }
}
