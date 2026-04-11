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
    public class GetTypeByIdHandler : IRequestHandler<GetTypeById, TypeDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTypeByIdHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TypeDTO?> Handle(GetTypeById request, CancellationToken cancellationToken)
        {

            var type = await _unitOfWork.GetReposoitory<Types, int>().GetByIdAsync(request.id);

            if (type == null) return null;

            return _mapper.Map<TypeDTO>(type);



        }
    }
}
