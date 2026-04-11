using System;
using System.Collections.Generic;
using System.Text;
using JobOffer.Application.DTOs;
using JobOffer.Application.Features.Categories.Commands;
using JobOffer.Core.Contracts;
using JobOffer.Core.Lookups;
using MediatR;

namespace JobOffer.Application.Features.Categories.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory , bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetReposoitory<Category, int>();
            var category = await repo.GetByIdAsync(request.id);

            if(category == null) return false;

            await repo.DeleteAsync(request.id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
