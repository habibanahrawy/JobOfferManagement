namespace JobOffer.Application.Services.Categories.Queries
{
    public record GetAllCategories : IRequest<IEnumerable<CategoryDTO>>;
    
}
