using AutoMapper;
using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Cases.Handlers
{
    public class CreateCases
    {
        public class Command : IRequest<CaseDTO>
        {
            public int Id { get; set; }
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
            public Command(Case childCase)
            {
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

        public class Handler : IRequestHandler<Command, CaseDTO>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CaseDTO> Handle(Command request, CancellationToken cancellationToken)
            {

                _context.Cases.Add(_mapper.Map<Case>(request));

                await _context.SaveChangesAsync(cancellationToken);

                var region = await _context.Cases.FirstOrDefaultAsync(x => x.Id == request.Id);
                return _mapper.Map<CaseDTO>(region);
            }
        }
    }
}
