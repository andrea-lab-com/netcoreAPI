using System.Collections.Generic;
using Web.Api.Core.Domain.Entities;

namespace Web.Api.Core.Dto.GatewayResponses.Repositories
{
  public sealed class ListJobLogResponse : BaseGatewayResponse
  {
    public List<JobLog> Items { get; }
    public ListJobLogResponse(List<JobLog> items, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
    {
            Items = items;
    }
  }
}
