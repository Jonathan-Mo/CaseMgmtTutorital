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
        public class Command : CaseDTO, IRequest<CaseDTO>
        {
            public Command(Case childCase)
            {
                this.Child = new Child();
                this.Reporter = new Reporter();
                //this.Id = childCase.Id;
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
