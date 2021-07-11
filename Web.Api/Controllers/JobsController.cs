using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Models.Request;
using Web.Api.Presenters;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IStartJobUseCase _startJobUseCase;
        private readonly StartJobPresenter _startJobPresenter;
        private readonly IMapper _mapper;

        public JobsController(IStartJobUseCase StartJobUseCase, StartJobPresenter StartJobPresenter, IMapper mapper)
        {
            _startJobUseCase = StartJobUseCase;
            _startJobPresenter = StartJobPresenter;
            _mapper = mapper;
        }

        // POST api/Jobs
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.StartJobRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            List<JobItem> items = _mapper.Map<List<JobItem>>(request.Items);

            await _startJobUseCase.Handle(new StartJobUseCaseRequest(request.Type, items), _startJobPresenter);




            return _startJobPresenter.ContentResult;
        }
    }
}
