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
        public class Command : ChildDTO, IRequest<ChildDTO>
        {
            public Command(Child child)
            {
                this.FirstName = child.FirstName;
                this.LastName = child.LastName;
                this.StreetAddress = child.StreetAddress;
                this.City = child.City;
                this.State = child.State;
                this.ZipCode = child.ZipCode;
                this.Details = child.Details;
                this.IsDeleted = child.IsDeleted;
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

                var region = await _context.Children.FirstOrDefaultAsync(x => x.FirstName == request.FirstName);
                var Child = new ChildDTO();
                Child = _mapper.Map<ChildDTO>(region);
                return Child;
            }
        }
    }
}
