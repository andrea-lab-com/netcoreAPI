using System.Collections.Generic;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Domain.Enums;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class GetJobLogUseCaseResponse : UseCaseResponseMessage
    {
        public List<JobLog> JobLogs { get; }
        public IEnumerable<string> Errors { get; }

        public GetJobLogUseCaseResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
        public GetJobLogUseCaseResponse(List<JobLog> jobLogs, bool success = false, string message = null) : base(success, message)
        {
            JobLogs = jobLogs;
        }

    }
}
