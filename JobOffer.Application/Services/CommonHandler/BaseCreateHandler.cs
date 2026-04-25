
using JobOffer.Core;

namespace JobOffer.Application.Services.CommonHandler
{
    public abstract class BaseCreateHandler<TRequest, TEntity, Dto> : IRequestHandler<TRequest, Dto>
    where TRequest : IRequest<Dto>
    where TEntity : BaseEntity<int>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<Dto> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);

            await _unitOfWork.GetReposoitory<TEntity, int>().CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Dto>(entity);
        }
    }
}
