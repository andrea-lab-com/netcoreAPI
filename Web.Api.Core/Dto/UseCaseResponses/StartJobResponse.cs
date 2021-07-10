using System.Collections.Generic;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class StartJobResponse : UseCaseResponseMessage 
    {
        public int Id { get; }
        public IEnumerable<string> Errors {  get; }

        public StartJobResponse(IEnumerable<string> errors, bool success=false, string message=null) : base(success, message)
        {
            Errors = errors;
        }

        public StartJobResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
