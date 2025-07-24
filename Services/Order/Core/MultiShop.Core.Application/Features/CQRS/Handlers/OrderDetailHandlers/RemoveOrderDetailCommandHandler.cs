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
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repositories;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repositories)
        {
            _repositories = repositories;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var values = await _repositories.GetByIdAsync(command.Id);
            await _repositories.RemoveAsync(values);

        }
    }
}
