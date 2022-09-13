using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Children.Handlers
{
    public class UpdateChildrenById
    {
        public class Command : ChildDTO, IRequest<ChildDTO>
        {
            public long idVerify;
            public int Id;
            public string FirstName { get; set; }
            public string? LastName { get; set; }
            public string? StreetAddress { get; set; }
            public int City { get; set; }
            public int State { get; set; }
            public string? ZipCode { get; set; }
            public string? Details { get; set; }

            public Command(long childID, Child child)
            {
                idVerify = childID;

                //this.Id = childCase.Id;
                this.FirstName = child.FirstName;
                this.LastName = child.LastName;
                this.StreetAddress = child.StreetAddress;
                this.City = child.City;
                this.State = child.State;
                this.ZipCode = child.ZipCode;
                this.Details = child.Details;
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
                if (request.idVerify != request.Id)
                {
                    return null;
                }

                var child = await _context.Children.FindAsync(request.idVerify);
                if (child == null || child.IsDeleted)
                {
                    return null;
                }

                child.FirstName = request.FirstName;
                child.LastName = request.LastName;
                child.StreetAddress = request.StreetAddress;
                child.City = request.City;
                child.State = request.State;
                child.ZipCode = request.ZipCode;
                child.Details = request.Details;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!ChildrenExists(request.idVerify))
                {
                    return null;
                }

                return null;



            }

            private bool ChildrenExists(long id)
            {
                return _context.Children.Any(e => e.Id == id);
            }
        }
    }
}
