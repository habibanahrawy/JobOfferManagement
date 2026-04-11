using System;
using System.Collections.Generic;
using System.Text;
using JobOffer.Application.Features.Typies.Commands;
using JobOffer.Core.Contracts;
using JobOffer.Core.Lookups;
using MediatR;

namespace JobOffer.Application.Features.Typies.Handlers
{
    public class DeleteTypeHandler : IRequestHandler<DeleteType, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteType request, CancellationToken cancellationToken)
        {

            var repo = _unitOfWork.GetReposoitory<Types, int>();
            var type = await repo.GetByIdAsync(request.id);

            if (type == null) return false;

            await repo.DeleteAsync(request.id);
            await _unitOfWork.SaveChangesAsync();
            return true;

        }
    }
}
