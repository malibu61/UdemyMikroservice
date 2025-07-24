using MultiShop.Core.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Core.Application.Interfaces;
using MultiShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repositories;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repositories)
        {
            _repositories = repositories;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repositories.GetByIdAsync(command.OrderDetailId);

            values.OrderDetailId = command.OrderDetailId;
            values.OrderingId = command.OrderingId;
            values.ProductPrice = command.ProductPrice;
            values.ProductName = command.ProductName;
            values.ProductAmount = command.ProductAmount;
            values.ProductTotalPrice = command.ProductTotalPrice;
            values.ProductId = command.ProductId;

            await _repositories.UpdateAsync(values);
        }
    }
}
