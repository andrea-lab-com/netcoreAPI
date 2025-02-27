﻿using System;
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
    internal sealed class JobRepository : IJobRepository
  {
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public JobRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
    {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
    }

    public async Task<CreateJobResponse> Create(Job job)
        {
            var jobEntity = _mapper.Map<JobEntity>(job);

            var errors = new List<Error>();

            var result = _applicationDbContext.Jobs.Add(jobEntity);

            try {
                _applicationDbContext.SaveChanges();

             
            } catch (Exception e) {
                errors.Add(new Error("E001", "Job isn't be added"));
            }

            return new CreateJobResponse(jobEntity.Id, errors.Count == 0, errors.Count == 0 ? null : errors);
        }
        public async Task<Job> FindById(int id)
        {
            var result = _applicationDbContext.Jobs.Where<JobEntity>(ji => ji.Id == id).FirstOrDefault();

            return _mapper.Map<Job>(result);
        }
    }
}
