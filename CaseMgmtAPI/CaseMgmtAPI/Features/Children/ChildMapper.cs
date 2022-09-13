using AutoMapper;
using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Children.DTO;

namespace CaseMgmtAPI.Features.Children
{
    public class ChildMapper : Profile
    {
        public ChildMapper()
        {
            CreateMap<Child, ChildDTO>();
            CreateMap<ChildDTO, Child>();
        }
    }
}
