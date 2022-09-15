using AutoMapper;
using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Children.DTO;
using static CaseMgmtAPI.Features.Children.Handlers.CreateChildren;

namespace CaseMgmtAPI.Features.Children
{
    public class ChildMapper : Profile
    {
        public ChildMapper()
        {
            //CreateMap<Child, Command>();
            CreateMap<Child, ChildDTO>();
            CreateMap<ChildDTO, Child>();
            CreateMap<IQueryable<Child>, ChildDTO>();
        }
    }
}
