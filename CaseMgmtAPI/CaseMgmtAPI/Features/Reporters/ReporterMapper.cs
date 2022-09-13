using AutoMapper;
using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Reporters.DTO;

namespace CaseMgmtAPI.Features.Reporters
{
    public class ReporterMapper : Profile
    {
        public ReporterMapper()
        {
            CreateMap<Reporter, ReporterDTO>();
            CreateMap<ReporterDTO, Reporter>();
        }
    }
}
