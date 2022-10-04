using CaseMgmtAPI.Domain.Entity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CaseMgmtAPI.Features.Cases.DTO
{
    public class CaseDTO
    {
        public int Id { get; set; }
        [Required]
        public Child Child { get; set; }
        public int ChildId { get; set; }
        [Required]
        public Reporter Reporter { get; set; }
        public int ReporterId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
