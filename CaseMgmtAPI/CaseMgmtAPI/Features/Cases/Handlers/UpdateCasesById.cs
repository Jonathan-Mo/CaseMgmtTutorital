using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Cases.Handlers
{
    public class UpdateCasesById
    {
        public class Command : CaseDTO, IRequest<CaseDTO>
        {
            public int idVerify;
            public int Id;

            public Command(int caseID, Case childCase)
            {
                idVerify = caseID;

                this.Child = childCase.Child;
                this.Reporter = childCase.Reporter;
                this.Id = childCase.Id;
                this.Child.FirstName = childCase.Child.FirstName;
                this.Child.LastName = childCase.Child.LastName;
                this.Child.StreetAddress = childCase.Child.StreetAddress;
                this.Child.City = childCase.Child.City;
                this.Child.State = childCase.Child.State;
                this.Child.ZipCode = childCase.Child.ZipCode;
                this.Child.Details = childCase.Child.Details;
                this.Reporter.FirstName = childCase.Reporter.FirstName;
                this.Reporter.LastName = childCase.Reporter.LastName;
                this.Reporter.Email = childCase.Reporter.Email;
                this.Reporter.Phone = childCase.Reporter.Phone;
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
                //if (request.idVerify != request.Id)
                //{
                //    return null;
                //}

                var childCase = await _context.Cases.FindAsync(request.idVerify);
                if (childCase == null || childCase.IsDeleted)
                {
                    return null;
                }

                childCase.Child = request.Child;
                childCase.Reporter = request.Reporter;
                childCase.Child.FirstName = request.Child.FirstName;
                childCase.Child.LastName = request.Child.LastName;
                childCase.Child.StreetAddress = request.Child.StreetAddress;
                childCase.Child.City = request.Child.City;
                childCase.Child.State = request.Child.State;
                childCase.Child.ZipCode = request.Child.ZipCode;
                childCase.Child.Details = request.Child.Details;
                childCase.Reporter.FirstName = request.Reporter.FirstName;
                childCase.Reporter.LastName = request.Reporter.LastName;
                childCase.Reporter.Email = request.Reporter.Email;
                childCase.Reporter.Phone = request.Reporter.Phone;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!CasesExists(request.idVerify))
                {
                    return null;
                }

                return null;



            }

            private bool CasesExists(long id)
            {
                return _context.Cases.Any(e => e.Id == id);
            }
        }
    }
}
