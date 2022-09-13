using System.ComponentModel.DataAnnotations.Schema;

namespace CaseMgmtAPI.Domain.Entity
{
    public class Case
    {
        public int Id { get; set; }

        [ForeignKey("ChildId")]
        public Child? Child { get; set; }
        public int ChildId { get; set; }

        [ForeignKey("ReporterId")]
        public Reporter? Reporter { get; set; }
        public int ReporterId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
