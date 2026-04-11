using System;
using System.Collections.Generic;
using System.Text;
using JobOffer.Application.DTOs;
using MediatR;

namespace JobOffer.Application.Features.Categories.Commands
{
    public record CreateCategory(string name) : IRequest<CategoryDTO>;
   
}
