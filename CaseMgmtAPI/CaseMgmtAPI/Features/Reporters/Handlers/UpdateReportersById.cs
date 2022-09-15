using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Features.Reporters.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Reporters.Handlers
{
    public class UpdateReportersById
    {
        public class Command : ReporterDTO, IRequest<ReporterDTO>
        {
            public int idVerify;
            public int Id;

            public Command(int reporterID, Reporter reporter)
            {
                idVerify = reporterID;

                this.FirstName = reporter.FirstName;
                this.LastName = reporter.LastName;
                this.Email = reporter.Email;
                this.Phone = reporter.Phone;
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
                //if (request.idVerify != request.Id)
                //{
                //    return null;
                //}

                var reporter = await _context.Reporters.FindAsync(request.idVerify);
                if (reporter == null || reporter.IsDeleted)
                {
                    return null;
                }

                reporter.FirstName = request.FirstName;
                reporter.LastName = request.LastName;
                reporter.Email = request.Email;
                reporter.Phone = request.Phone;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!ReportersExist(request.idVerify))
                {
                    return null;
                }

                return null;
            }

            private bool ReportersExist(long id)
            {
                return _context.Reporters.Any(e => e.Id == id);
            }
        }
    }
}
