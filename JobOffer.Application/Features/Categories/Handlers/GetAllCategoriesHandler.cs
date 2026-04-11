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
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, IEnumerable<CategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            var categories =await _unitOfWork.GetReposoitory<Category , int>().GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);


        }
    }

}
