using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingRequestCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveOrderingRequestCommand(int id)
        {
            Id = id;
        }
    }
}
