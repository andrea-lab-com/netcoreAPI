using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Serialization;

namespace Web.Api.Presenters
{
    public sealed class StartJobPresenter : IOutputPort<StartJobResponse>
    {
        public JsonContentResult ContentResult { get; }

        public StartJobPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(StartJobResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
