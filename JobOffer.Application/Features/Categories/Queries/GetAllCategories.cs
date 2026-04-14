namespace JobOffer.Application.Features.Categories.Queries
{
    public record GetAllCategories : IRequest<IEnumerable<CategoryDTO>>;
    
}
