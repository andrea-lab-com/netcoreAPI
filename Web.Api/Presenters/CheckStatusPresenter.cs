using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Serialization;

namespace Web.Api.Presenters
{
    public sealed class CheckStatusPresenter : IOutputPort<CheckStatusUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public CheckStatusPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(CheckStatusUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
