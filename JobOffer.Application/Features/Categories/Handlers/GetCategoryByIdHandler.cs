using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using JobOffer.Application.DTOs;
using JobOffer.Application.Features.Categories.Queries;
using JobOffer.Core.Contracts;
using JobOffer.Core.Lookups;
using MediatR;

namespace JobOffer.Application.Features.Categories.Handlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryById, CategoryDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(GetCategoryById request, CancellationToken cancellationToken)
        {

            var category = await _unitOfWork.GetReposoitory<Category , int>().GetByIdAsync(request.id);

            if (category == null) return null;

            return _mapper.Map<CategoryDTO>(category);


        }
    }
}
