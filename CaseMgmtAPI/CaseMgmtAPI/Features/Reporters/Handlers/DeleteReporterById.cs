using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Features.Reporters.DTO;
using CaseMgmtAPI.Infra;
using MediatR;

namespace CaseMgmtAPI.Features.Reporters.Handlers
{
    public class DeleteReporterById
    {
        public class Command : ReporterDTO, IRequest<ReporterDTO>
        {
            public long id;
            public Command(long reporterID)
            {
                id = reporterID;
            }
        }

        public class Handler : IRequestHandler<Command, ReporterDTO?>
        {
            private readonly CaseMgmtContext _context;

            public Handler(CaseMgmtContext context)
            {
                _context = context;
            }

            public async Task<ReporterDTO?> Handle(Command request, CancellationToken cancellationToken)
            {
                var reporter = await _context.Reporters.FindAsync(request.id);

                if (reporter == null)
                {
                    return null;
                }
                if (reporter.IsDeleted)
                {
                    reporter.IsDeleted = false;
                    await _context.SaveChangesAsync();

                    return null;
                }

                reporter.IsDeleted = true;

                await _context.SaveChangesAsync();

                return null;
            }
        }
    }
}
