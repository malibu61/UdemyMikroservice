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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repositories;

        public UpdateAddressCommandHandler(IRepository<Address> repositories)
        {
            _repositories = repositories;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repositories.GetByIdAsync(command.AddressId);

            values.Detail = command.Detail;
            values.District = command.District;
            values.City = command.City;
            values.UserId = command.UserId;

            await _repositories.UpdateAsync(values);
        }
    }
}
