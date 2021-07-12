using System.Collections.Generic;

namespace Web.Api.Core.Dto.GatewayResponses.Repositories
{
  public sealed class CreateItemJobResponse : BaseGatewayResponse
  {
    public int Id { get; }
    public CreateItemJobResponse(int id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
    {
      Id = id;
    }
  }
}
