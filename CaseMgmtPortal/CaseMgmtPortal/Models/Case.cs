using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CaseMgmtPortal.Models
{
    public class Case
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

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        public Case()
        {
            Child = new Child();
            Reporter = new Reporter();
        }
    }
}
