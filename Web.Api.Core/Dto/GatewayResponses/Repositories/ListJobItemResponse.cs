using System.Collections.Generic;
using Web.Api.Core.Domain.Entities;

namespace Web.Api.Core.Dto.GatewayResponses.Repositories
{
  public sealed class ListJobItemResponse : BaseGatewayResponse
  {
    public List<JobItem> Items { get; }
    public ListJobItemResponse(List<JobItem> items, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
    {
            Items = items;
    }
  }
}
