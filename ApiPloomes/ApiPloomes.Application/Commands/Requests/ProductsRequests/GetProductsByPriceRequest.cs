﻿using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.ProductRequests
{
    public class GetProductsByPriceRequest : IRequest<IEnumerable<GetProductByIdResponse>>
    {
    }
}
