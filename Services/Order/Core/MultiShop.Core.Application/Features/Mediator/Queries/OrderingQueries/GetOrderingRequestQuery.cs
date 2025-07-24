using MediatR;
using MultiShop.Core.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingRequestQuery : IRequest<List<GetOrderingRequestQueryResult>>
    {
    }
}
