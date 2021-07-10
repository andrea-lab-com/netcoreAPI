using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Presenters;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IStartJobUseCase _startJobUseCase;
        private readonly StartJobPresenter _startJobPresenter;

        public JobsController(IStartJobUseCase StartJobUseCase, StartJobPresenter StartJobPresenter)
        {
            _startJobUseCase = StartJobUseCase;
            _startJobPresenter = StartJobPresenter;
        }

        // POST api/Jobs
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.StartJobRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _startJobUseCase.Handle(new StartJobRequest(request.Type,request.Items), _startJobPresenter);
            return _startJobPresenter.ContentResult;
        }
    }
}
