using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace JobOffer.Application.Features.Categories.Commands
{
    public record DeleteCategory(int id) : IRequest<bool>;
   
}
