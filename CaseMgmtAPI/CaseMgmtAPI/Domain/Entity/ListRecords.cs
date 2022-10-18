using CaseMgmtAPI.Features.Cases.DTO;

namespace CaseMgmtAPI.Domain.Entity
{
    public class ListRecords
    {
        public IEnumerable<CaseDTO> ListOfRecords { get; set; }

        public int NumRecords { get; set; }
    }
}
