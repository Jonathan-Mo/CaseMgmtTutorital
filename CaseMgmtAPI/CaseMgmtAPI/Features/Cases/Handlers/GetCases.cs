using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace CaseMgmtAPI.Features.Cases.Handlers
{
    public class GetCases
    {
        public class Query : IRequest<ActionResult<IEnumerable<CaseDTO>>>
        { }

        public class Handler : IRequestHandler<Query, ActionResult<IEnumerable<CaseDTO>>>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ActionResult<IEnumerable<CaseDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var childCase = await _context.Cases
                   .Where(x => !x.IsDeleted)
                   .AsNoTracking()
                   .ProjectTo<CaseDTO>(_mapper.ConfigurationProvider)
                   .ToListAsync();

                return childCase;
            }

        }
    }
}
