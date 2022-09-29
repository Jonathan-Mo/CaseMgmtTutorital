using CaseMgmtAPI.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Features.Cases.DTO
{
    public class CaseDTO
    {
        public int Id { get; set; }
        [Required]
        public Child Child { get; set; }
        [Required]
        public Reporter Reporter { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}
