
using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Serialization;

namespace Web.Api.Presenters
{
    public sealed class GetJobLogPresenter : IOutputPort<GetJobLogUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetJobLogPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetJobLogUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
