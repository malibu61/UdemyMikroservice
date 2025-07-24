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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repositories;

        public CreateAddressCommandHandler(IRepository<Address> repositories)
        {
            _repositories = repositories;
        }

        public async Task Handle(CreateAddressCommand command)
        {
            await _repositories.CreateAsync(new Address
            {
                City = command.City,
                Detail = command.Detail,
                District = command.District,
                UserId = command.UserId
            });

        }
    }
}
