using AutoMapper;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Features.Reporters.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Reporters.Handlers
{
    public class GetReportersById
    {
        public class Query : IRequest<ReporterDTO>
        {
            public long Id;

            public Query(long reporterId)
            {
                this.Id = reporterId;
            }
        }

        public class Handler : IRequestHandler<Query, ReporterDTO?>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ReporterDTO?> Handle(Query request, CancellationToken cancellationToken)
            {
                long j = request.Id;

                var reporters = await _context.Reporters.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (reporters == null)
                {
                    return null;
                }
                if (reporters.IsDeleted.Equals(true))
                {
                    return null;
                }
                return _mapper.Map<ReporterDTO>(reporters);
            }
        }
    }
}
