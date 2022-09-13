using AutoMapper;
using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Cases.Handlers
{
    public class GetCasesById
    {
        public class Query : IRequest<CaseDTO>
        {
            public long Id;

            public Query(long userRegion)
            {
                this.Id = userRegion;
            }
        }

        public class Handler : IRequestHandler<Query, CaseDTO?>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<CaseDTO?> Handle(Query request, CancellationToken cancellationToken)
            {
                long j = request.Id;

                var regions = await _context.Cases.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (regions == null)
                {
                    return null;
                }
                if (regions.IsDeleted.Equals(true))
                {
                    return null;
                }
                return _mapper.Map<CaseDTO>(regions);
            }
        }
    }
}
