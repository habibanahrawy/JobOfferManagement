namespace JobOffer.Application.Services.Categories.Queries
{
    public record GetCategoryById(int id) : IRequest<CategoryDTO?>;
    
}
