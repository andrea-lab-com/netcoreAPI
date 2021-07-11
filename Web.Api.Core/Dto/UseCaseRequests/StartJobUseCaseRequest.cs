using System.Collections.Generic;
using System.ComponentModel;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Domain.Enums;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
  public class StartJobUseCaseRequest : IUseCaseRequest<StartJobUseCaseResponse>
  {
    public JobType Type { get; }
    public List<JobItem> Items { get; }

    public StartJobUseCaseRequest(JobType type, List<JobItem> items)
    {
            Type = type;
            Items = items;
    }
  }
}
