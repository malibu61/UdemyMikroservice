using MediatR;
using MultiShop.Core.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Core.Application.Interfaces;
using MultiShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingRequestCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingRequestCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderingId);
            values.OrderDate = request.OrderDate;
            values.OrderingId = request.OrderingId;
            values.UserId = request.UserId;
            values.TotalPrice = request.TotalPrice;

            await _repository.UpdateAsync(values);
        }
    }
}
