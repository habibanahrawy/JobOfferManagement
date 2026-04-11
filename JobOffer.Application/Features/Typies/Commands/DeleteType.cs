using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace JobOffer.Application.Features.Typies.Commands
{
    public record DeleteType(int id) : IRequest<bool>; 
  
}
