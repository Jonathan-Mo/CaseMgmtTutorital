using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Infra;
using MediatR;

namespace CaseMgmtAPI.Features.Cases.Handlers
{
    public class DeleteCaseById
    {
        public class Command : CaseDTO, IRequest<CaseDTO>
        {
            public long id;
            public Command(long caseID)
            {
                id = caseID;
            }
        }

        public class Handler : IRequestHandler<Command, CaseDTO?>
        {
            private readonly CaseMgmtContext _context;

            public Handler(CaseMgmtContext context)
            {
                _context = context;
            }

            public async Task<CaseDTO?> Handle(Command request, CancellationToken cancellationToken)
            {
                var childCase = await _context.Cases.FindAsync(request.id);

                if (childCase == null)
                {
                    return null;
                }
                if (childCase.IsDeleted)
                {
                    childCase.IsDeleted = false;
                    await _context.SaveChangesAsync();

                    return null;
                }

                childCase.IsDeleted = true;

                await _context.SaveChangesAsync();

                return null;


            }
        }
    }
}
