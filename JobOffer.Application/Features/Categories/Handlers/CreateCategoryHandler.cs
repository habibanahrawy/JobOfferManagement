using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using JobOffer.Application.DTOs;
using JobOffer.Application.Features.Categories.Commands;
using JobOffer.Core.Contracts;
using JobOffer.Core.Lookups;
using MediatR;

namespace JobOffer.Application.Features.Categories.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, CategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.name
            };

            await _unitOfWork.GetReposoitory<Category, int>().CreateAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(category);

        }
    }

}
