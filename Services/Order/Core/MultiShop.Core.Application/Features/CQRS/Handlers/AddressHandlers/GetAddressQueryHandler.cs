using MultiShop.Core.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Core.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Core.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Core.Application.Interfaces;
using MultiShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repositories;

        public GetAddressQueryHandler(IRepository<Address> repositories)
        {
            _repositories = repositories;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repositories.GetAllAsync();

            return values.Select(x => new GetAddressQueryResult()
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }

    }
}
