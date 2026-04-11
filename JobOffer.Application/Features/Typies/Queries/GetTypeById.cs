using System;
using System.Collections.Generic;
using System.Text;
using JobOffer.Application.DTOs;
using MediatR;

namespace JobOffer.Application.Features.Typies.Queries
{
    public record GetTypeById(int id) : IRequest<TypeDTO?>;
}
