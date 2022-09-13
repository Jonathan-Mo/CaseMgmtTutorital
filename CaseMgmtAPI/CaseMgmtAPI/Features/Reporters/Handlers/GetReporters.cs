using AutoMapper;
using AutoMapper.QueryableExtensions;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Features.Reporters.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Reporters.Handlers
{
    public class GetReporters
    {
        public class Query : IRequest<ActionResult<IEnumerable<ReporterDTO>>>
        { }

        public class Handler : IRequestHandler<Query, ActionResult<IEnumerable<ReporterDTO>>>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ActionResult<IEnumerable<ReporterDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var reporter = await _context.Reporters
                   .Where(x => !x.IsDeleted)
                   .AsNoTracking()
                   .ProjectTo<ReporterDTO>(_mapper.ConfigurationProvider)
                   .ToListAsync();

                return reporter;
            }

        }
    }
}
