﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OLBIL.OncologyApplication.Exceptions;
using OLBIL.OncologyData;
using OLBIL.OncologyDomain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OLBIL.OncologyApplication.Beds.Commands
{
    public class DeleteBedCommand: IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteBedCommand>
        {
            private readonly OncologyContext _context;
            private readonly IMapper _mapper;

            public Handler(OncologyContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteBedCommand request, CancellationToken cancellationToken)
            {
                var building = await _context.Beds
                    .Where(p => p.BedId == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);
                if (building == null)
                {
                    throw new NotFoundException(nameof(Bed), nameof(building.BedId), request.Id);
                }

                _context.Beds.Remove(building);

                await _context.SaveChangesAsync(cancellationToken);
                return new Unit();
            }
        }
    }
}
