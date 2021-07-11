using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Domain.Enums;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Data.Entities;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;

namespace Web.Api.Infrastructure.Data.EntityFramework.Repositories
{
  internal sealed class JobItemRepository : IJobItemRepository
  {
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public JobItemRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
    {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
    }

    public async Task<ListJobItemResponse> List(int jobId)
        {

            var errors = new List<Error>();

            var result = _applicationDbContext.JobItems.Where<JobItemEntity>(ji => ji.JobId == jobId).ToList();

            var items = _mapper.Map<List<JobItem>>(result);


            return new ListJobItemResponse(items, errors.Count == 0, errors.Count == 0 ? null : errors);
        }


        public async Task<UpdateJobItemResponse> Update(JobItem jobItem, JobItemStatus jobItemStatus)
        {

            var errors = new List<Error>();

            var entity = _applicationDbContext.JobItems.FirstOrDefault(item => item.Id == jobItem.Id);

            if (entity != null)
            {
                entity.Status = (int)jobItemStatus;
                _applicationDbContext.SaveChanges();

            } else {
                errors.Add(new Error("E002", "JobItem not found"));

            }
            return new UpdateJobItemResponse(entity.Id, errors.Count == 0, errors.Count == 0 ? null : errors);
        }
    }
}
