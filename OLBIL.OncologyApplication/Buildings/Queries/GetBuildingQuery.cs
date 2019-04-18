﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OLBIL.OncologyApplication.Exceptions;
using OLBIL.OncologyApplication.Models;
using OLBIL.OncologyData;
using OLBIL.OncologyDomain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OLBIL.OncologyApplication.Buildings.Queries
{
    public class GetBuildingQuery : IRequest<BuildingModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetBuildingQuery, BuildingModel>
        {
            private readonly OncologyContext _context;
            private readonly IMapper _mapper;

            public Handler(OncologyContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BuildingModel> Handle(GetBuildingQuery request, CancellationToken cancellationToken)
            {
                var item = _mapper.Map<BuildingModel>(await _context
                    .Buildings.Where(o => o.BuildingId == request.Id)
                    .SingleOrDefaultAsync(cancellationToken));

                if (item == null)
                {
                    throw new NotFoundException(nameof(Building), nameof(item.BuildingId), request.Id);
                }

                return item;
            }
        }
    }
}
