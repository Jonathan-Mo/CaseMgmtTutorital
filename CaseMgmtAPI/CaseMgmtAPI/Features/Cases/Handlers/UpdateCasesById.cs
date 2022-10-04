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

                this.Id = childCase.Id;
                this.Child = childCase.Child;
                this.ChildId = childCase.ChildId;
                this.Reporter = childCase.Reporter;
                this.ReporterId = childCase.ReporterId;
                this.Child.FirstName = childCase.Child.FirstName;
                this.Child.MiddleName = childCase.Child.MiddleName;
                this.Child.LastName = childCase.Child.LastName;
                this.Child.StreetAddress = childCase.Child.StreetAddress;
                this.Child.City = childCase.Child.City;
                this.Child.State = childCase.Child.State;
                this.Child.ZipCode = childCase.Child.ZipCode;
                this.Child.Details = childCase.Child.Details;
                this.Reporter.FirstName = childCase.Reporter.FirstName;
                this.Reporter.MiddleName = childCase.Reporter.MiddleName;
                this.Reporter.LastName = childCase.Reporter.LastName;
                this.Reporter.Email = childCase.Reporter.Email;
                this.Reporter.Phone = childCase.Reporter.Phone;
                this.IsDeleted = childCase.IsDeleted;
                this.Date = childCase.Date;
                this.Status = childCase.Status;
                this.Notes = childCase.Notes;
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

                childCase.Id = request.Id;
                childCase.Child = request.Child;
                childCase.ChildId = request.ChildId;
                childCase.Reporter = request.Reporter;
                childCase.ReporterId = request.ReporterId;
                childCase.Child.FirstName = request.Child.FirstName;
                childCase.Child.MiddleName = request.Child.MiddleName;
                childCase.Child.LastName = request.Child.LastName;
                childCase.Child.StreetAddress = request.Child.StreetAddress;
                childCase.Child.City = request.Child.City;
                childCase.Child.State = request.Child.State;
                childCase.Child.ZipCode = request.Child.ZipCode;
                childCase.Child.Details = request.Child.Details;
                childCase.Reporter.FirstName = request.Reporter.FirstName;
                childCase.Reporter.MiddleName = request.Reporter.MiddleName;
                childCase.Reporter.LastName = request.Reporter.LastName;
                childCase.Reporter.Email = request.Reporter.Email;
                childCase.Reporter.Phone = request.Reporter.Phone;
                childCase.IsDeleted = request.IsDeleted;
                childCase.Date = request.Date;
                childCase.Status = request.Status;
                childCase.Notes = request.Notes;
                childCase.UpdateDate = request.UpdateDate;

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
