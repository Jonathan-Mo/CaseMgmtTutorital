using CaseMgmtPortal.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CaseMgmtPortal.ModelDTOs
{
    public class CaseDTO
    {
        public int Id { get; set; }

        [JsonProperty("child")]
        [Required]
        [ForeignKey("ChildId")]
        public Child Child { get; set; }
        public int ChildId { get; set; }

        [JsonProperty("reporter")]
        [Required]
        [ForeignKey("ReporterId")]
        public Reporter Reporter { get; set; }
        public int ReporterId { get; set; }
        public bool IsDeleted { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        public DateTime UpdateDate { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("notes")]
        public string? Notes { get; set; }
    }
}
