using MultiShop.Core.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Core.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Core.Application.Interfaces;
using MultiShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetByIdOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repositories;

        public GetByIdOrderDetailQueryHandler(IRepository<OrderDetail> repositories)
        {
            _repositories = repositories;
        }

        public async Task<GetByIdOrderDetailQueryResult> Handle(GetByIdOrderDetailQuery query)
        {
            var values = await _repositories.GetByIdAsync(query.Id);

            return new GetByIdOrderDetailQueryResult()
            {
                OrderDetailId = values.OrderDetailId,
                ProductPrice = values.ProductPrice,
                ProductName = values.ProductName,
                ProductId = values.ProductId,
                ProductAmount = values.ProductAmount,
                ProductTotalPrice = values.ProductTotalPrice
            };
        }
    }
}
