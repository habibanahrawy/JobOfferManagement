using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using JobOffer.Application.DTOs;
using JobOffer.Application.Features.Typies.Queries;
using JobOffer.Core.Contracts;
using JobOffer.Core.Lookups;
using MediatR;

namespace JobOffer.Application.Features.Typies.Handlers
{
    public class GetAllTypiesHandler : IRequestHandler<GetAllTypies, IEnumerable<TypeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTypiesHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeDTO>> Handle(GetAllTypies request, CancellationToken cancellationToken)
        {
            var typies = await _unitOfWork.GetReposoitory<Types, int>().GetAllAsync();

            if (typies == null) return null;

            return _mapper.Map<IEnumerable<TypeDTO>>(typies);


        }
    }
}
