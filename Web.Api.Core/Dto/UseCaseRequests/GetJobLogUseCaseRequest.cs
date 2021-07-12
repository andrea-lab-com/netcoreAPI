using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
  public class GetJobLogUseCaseRequest : IUseCaseRequest<GetJobLogUseCaseResponse>
  {
    public int JobId { get; }

    public GetJobLogUseCaseRequest(int jobId)
    {
            JobId = jobId;
    }
  }
}
