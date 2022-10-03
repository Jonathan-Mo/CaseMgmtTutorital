using AutoMapper;

namespace CaseMgmtPortal.Controllers
{
    public class CaseMapper : Profile
    {
        public CaseMapper()
        {
            CreateMap<Models.Value, Models.Case>();
        }
    }
}
