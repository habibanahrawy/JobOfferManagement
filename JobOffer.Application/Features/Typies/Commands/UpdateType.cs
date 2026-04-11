using System;
using System.Collections.Generic;
using System.Text;
using JobOffer.Application.DTOs;
using MediatR;

namespace JobOffer.Application.Features.Typies.Commands
{
    public record UpdateType(int id, string name) : IRequest<bool>;

}
