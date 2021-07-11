using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
  public class CheckStatusUseCaseRequest : IUseCaseRequest<CheckStatusUseCaseResponse>
  {
    public int JobId { get; }

    public CheckStatusUseCaseRequest(int jobId)
    {
            JobId = jobId;
    }
  }
}
