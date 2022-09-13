using AutoMapper;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Children.Handlers
{
    public class GetChildrenById
    {
        public class Query : IRequest<ChildDTO>
        {
            public long Id;

            public Query(long childId)
            {
                this.Id = childId;
            }
        }

        public class Handler : IRequestHandler<Query, ChildDTO?>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ChildDTO?> Handle(Query request, CancellationToken cancellationToken)
            {
                long j = request.Id;

                var regions = await _context.Children.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (regions == null)
                {
                    return null;
                }
                if (regions.IsDeleted.Equals(true))
                {
                    return null;
                }
                return _mapper.Map<ChildDTO>(regions);
            }
        }
    }
}
