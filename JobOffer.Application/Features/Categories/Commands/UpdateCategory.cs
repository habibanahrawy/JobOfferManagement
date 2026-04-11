using System;
using System.Collections.Generic;
using System.Text;
using JobOffer.Application.DTOs;
using MediatR;

namespace JobOffer.Application.Features.Categories.Commands
{
    public record UpdateCategory(int id, string name) : IRequest<bool>;
   
}
