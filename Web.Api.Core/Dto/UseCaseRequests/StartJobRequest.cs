using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
  public class StartJobRequest : IUseCaseRequest<StartJobResponse>
  {
    public string Type { get; }
    public int Items { get; }

    public StartJobRequest(string type, int items)
    {
            Type = type;
            Items = items;
    }
  }
}
