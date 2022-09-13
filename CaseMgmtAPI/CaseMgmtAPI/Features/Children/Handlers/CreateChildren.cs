using AutoMapper;
using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseMgmtAPI.Features.Children.Handlers
{
    public class CreateChildren
    {
        public class Command : IRequest<ChildDTO>
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string? LastName { get; set; }
            public string? StreetAddress { get; set; }
            public int City { get; set; }
            public int State { get; set; }
            public string? ZipCode { get; set; }
            public string? Details { get; set; }

            public Command(Child child)
            {
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

        public class Handler : IRequestHandler<Command, ChildDTO>
        {
            private readonly CaseMgmtContext _context;
            private readonly IMapper _mapper;

            public Handler(CaseMgmtContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ChildDTO> Handle(Command request, CancellationToken cancellationToken)
            {

                _context.Children.Add(_mapper.Map<Child>(request));

                await _context.SaveChangesAsync(cancellationToken);

                var region = await _context.Children.FirstOrDefaultAsync(x => x.Id == request.Id);
                return _mapper.Map<ChildDTO>(region);
            }
        }
    }
}
