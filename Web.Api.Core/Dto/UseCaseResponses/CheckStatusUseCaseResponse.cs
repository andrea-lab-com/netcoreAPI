using System.Collections.Generic;
using Web.Api.Core.Domain.Enums;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class CheckStatusUseCaseResponse : UseCaseResponseMessage
    {
        public int JobId { get; }
        public JobType JobType { get; }
        public int TotalItems { get; }
        public int ProcessedItems{ get; }
        public int FailedItems { get; }

        public IEnumerable<string> Errors { get; }

        public CheckStatusUseCaseResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
        public CheckStatusUseCaseResponse(int jobId, JobType jobType, int totalItems, int processedItems, int failedItems, bool success = false, string message = null) : base(success, message)
        {
            JobId = jobId;
            JobType = jobType;
            TotalItems = totalItems;
            ProcessedItems = processedItems;
            FailedItems = failedItems;
        }

    }
}
