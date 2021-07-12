using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;

namespace Web.Api.Infrastructure.Data.EntityFramework.Repositories
{
    internal sealed class JobLogRepository : IJobLogRepository
  {
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public JobLogRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
    {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
    }


        public async Task<ListJobLogResponse> List(int jobId)
        {

            var errors = new List<Error>();

            var result = _applicationDbContext.JobLogs.Where<JobLogEntity>(ji => ji.JobId == jobId).ToList();

            var items = _mapper.Map<List<JobLog>>(result);

            return new ListJobLogResponse(items, errors.Count == 0, errors.Count == 0 ? null : errors);
        }

    }
}
