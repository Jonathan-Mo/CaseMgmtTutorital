using AutoMapper;
using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Cases.DTO;

namespace CaseMgmtAPI.Features.Cases
{
    public class CaseMapper : Profile
    {
        public CaseMapper()
        {
            CreateMap<Case, CaseDTO>();
            CreateMap<CaseDTO, Case>();
            //CreateMap<CaseDTO, ListRecords>();
        }
    }
}
