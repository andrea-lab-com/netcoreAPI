using System.ComponentModel;
using Web.Api.Core.Domain.Enums;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
  public class StartJobRequest : IUseCaseRequest<StartJobResponse>
  {

    [Description("JobType: BULK, BATCH")]
    public JobType Type { get; }
    public int Items { get; }

    public StartJobRequest(JobType type, int items)
    {
            Type = type;
            Items = items;
    }
  }
}
