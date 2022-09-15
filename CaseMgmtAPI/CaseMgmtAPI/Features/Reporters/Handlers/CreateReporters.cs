using AutoMapper;
using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Features.Reporters.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Reporters.Handlers
{
    public class CreateReporters
    {
        public class Command : ReporterDTO, IRequest<ReporterDTO>
        {
            public Command(Reporter reporter)
            {
                this.FirstName = reporter.FirstName;
                this.LastName = reporter.LastName;
                this.Email = reporter.Email;
                this.Phone = reporter.Phone;
            }
        }

        public class Handler : IRequestHandler<Command, ReporterDTO>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ReporterDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Reporters.Add(_mapper.Map<Reporter>(request));

                await _context.SaveChangesAsync(cancellationToken);

                var reporter = await _context.Reporters.FirstOrDefaultAsync(x => x.FirstName == request.FirstName);
                return _mapper.Map<ReporterDTO>(reporter);
            }
        }
    }
}
