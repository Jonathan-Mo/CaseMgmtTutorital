using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CaseMgmtPortal.Models
{
    public class Child
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        [Required(ErrorMessage = "Please enter the child's first name.")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter the child's last name.")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the child's street address.")]
        [StringLength(30)]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Please enter the child's city.")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please select the child's state.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter the child's ZIP Code.")]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter neglect details about the child.")]
        [StringLength(450)]
        public string Details { get; set; }

        public bool IsDeleted { get; set; }
    }
}
