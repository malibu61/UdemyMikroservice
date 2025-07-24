using MultiShop.Core.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Core.Application.Interfaces;
using MultiShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repositories;

        public RemoveAddressCommandHandler(IRepository<Address> repositories)
        {
            _repositories = repositories;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            var values = await _repositories.GetByIdAsync(command.Id);
            await _repositories.RemoveAsync(values);

        }
    }
}
