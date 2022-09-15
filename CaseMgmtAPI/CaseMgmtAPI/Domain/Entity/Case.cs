using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseMgmtAPI.Domain.Entity
{
    public class Case
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("ChildId")]
        public Child Child { get; set; }
        public int ChildId { get; set; }

        [Required]
        [ForeignKey("ReporterId")]
        public Reporter Reporter { get; set; }
        public int ReporterId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
