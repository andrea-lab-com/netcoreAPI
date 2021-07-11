using System.Collections.Generic;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class StartJobUseCaseResponse : UseCaseResponseMessage 
    {
        public int Id { get; }
        public IEnumerable<string> Errors {  get; }

        public StartJobUseCaseResponse(IEnumerable<string> errors, bool success=false, string message=null) : base(success, message)
        {
            Errors = errors;
        }

        public StartJobUseCaseResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
