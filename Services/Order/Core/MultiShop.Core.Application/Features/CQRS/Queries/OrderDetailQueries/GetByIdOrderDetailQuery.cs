  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetByIdOrderDetailQuery
    {
        public int Id { get; set; }

        public GetByIdOrderDetailQuery(int id)
        {
            Id = id;
        }
    }
}
