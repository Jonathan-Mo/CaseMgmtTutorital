using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Infra;
using MediatR;

namespace CaseMgmtAPI.Features.Children.Handlers
{
    public class DeleteChildById
    {
        public class Command : ChildDTO, IRequest<ChildDTO>
        {
            public long id;
            public Command(long childID)
            {
                id = childID;
            }
        }

        public class Handler : IRequestHandler<Command, ChildDTO?>
        {
            private readonly CaseMgmtContext _context;

            public Handler(CaseMgmtContext context)
            {
                _context = context;
            }

            public async Task<ChildDTO?> Handle(Command request, CancellationToken cancellationToken)
            {
                var child = await _context.Children.FindAsync(request.id);

                if (child == null)
                {
                    return null;
                }
                if (child.IsDeleted)
                {
                    child.IsDeleted = false;
                    await _context.SaveChangesAsync();

                    return null;
                }

                child.IsDeleted = true;

                await _context.SaveChangesAsync();

                return null;
            }
        }
    }
}
