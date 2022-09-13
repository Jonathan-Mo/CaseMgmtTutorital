using AutoMapper;
using AutoMapper.QueryableExtensions;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Children.Handlers
{
    public class GetChildren
    {
        public class Query : IRequest<ActionResult<IEnumerable<ChildDTO>>>
        { }

        public class Handler : IRequestHandler<Query, ActionResult<IEnumerable<ChildDTO>>>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ActionResult<IEnumerable<ChildDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var child = await _context.Cases
                   .Where(x => !x.IsDeleted)
                   .AsNoTracking()
                   .ProjectTo<ChildDTO>(_mapper.ConfigurationProvider)
                   .ToListAsync();

                return child;
            }

        }
    }
}
