using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Domain.Entity
{
    public class Child
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide the child's first name.")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Please provide the child's last name.")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide the child's street address.")]
        [StringLength(30)]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Please provide the child's city.")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please provide the child's state.")]
        [StringLength(25)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please provide the child's ZIP code.")]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please provide neglect details for the child.")]
        [StringLength(450)]
        public string Details { get; set; }

        public bool IsDeleted { get; set; }
    }
}
