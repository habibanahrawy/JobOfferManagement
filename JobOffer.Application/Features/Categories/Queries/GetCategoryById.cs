using System;
using System.Collections.Generic;
using System.Text;
using JobOffer.Application.DTOs;
using MediatR;

namespace JobOffer.Application.Features.Categories.Queries
{
    public record GetCategoryById(int id) : IRequest<CategoryDTO?>;
    
}
