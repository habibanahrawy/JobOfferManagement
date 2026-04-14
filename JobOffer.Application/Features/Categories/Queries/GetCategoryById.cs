namespace JobOffer.Application.Features.Categories.Queries
{
    public record GetCategoryById(int id) : IRequest<CategoryDTO?>;
    
}
