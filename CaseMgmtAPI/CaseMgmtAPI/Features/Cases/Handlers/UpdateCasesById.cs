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
            public long idVerify;
            public int Id;
            public int ChildId { get; set; }
            public string FirstName { get; set; }
            public string? LastName { get; set; }
            public string? StreetAddress { get; set; }
            public int City { get; set; }
            public int State { get; set; }
            public string? ZipCode { get; set; }
            public string? Details { get; set; }
            public int ReporterId { get; set; }
            public string? ReporterFirstName { get; set; }
            public string? ReporterLastName { get; set; }
            public string? ReporterEmail { get; set; }
            public string? ReporterPhone { get; set; }

            public Command(long caseID, Case childCase)
            {
                idVerify = caseID;

                //this.Id = childCase.Id;
                //this.ChildId = childCase.ChildId;
                this.FirstName = childCase.Child.FirstName;
                this.LastName = childCase.Child.LastName;
                this.StreetAddress = childCase.Child.StreetAddress;
                this.City = childCase.Child.City;
                this.State = childCase.Child.State;
                this.ZipCode = childCase.Child.ZipCode;
                this.Details = childCase.Child.Details;
                //this.ReporterId = childCase.Reporter.Id;
                this.ReporterFirstName = childCase.Reporter.FirstName;
                this.ReporterLastName = childCase.Reporter.LastName;
                this.ReporterEmail = childCase.Reporter.Email;
                this.ReporterPhone = childCase.Reporter.Phone;
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
                if (request.idVerify != request.Id)
                {
                    return null;
                }

                var childCase = await _context.Cases.FindAsync(request.idVerify);
                if (childCase == null || childCase.IsDeleted)
                {
                    return null;
                }

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
