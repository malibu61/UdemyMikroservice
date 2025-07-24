using MultiShop.Core.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Core.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Core.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Core.Application.Interfaces;
using MultiShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repositories;

        public GetAddressByIdQueryHandler(IRepository<Address> repositories)
        {
            _repositories = repositories;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repositories.GetByIdAsync(query.Id);

            return new GetAddressByIdQueryResult()
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId
            };
        }
    }
}
