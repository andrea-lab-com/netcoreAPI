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

        private readonly ICheckStatusUseCase _checkStatusUseCase;
        private readonly CheckStatusPresenter _checkStatusPresenter;


        private readonly IGetJobLogUseCase _getJobLogUseCase;
        private readonly GetJobLogPresenter _getJobLogPresenter;

        private readonly IMapper _mapper;

        public JobsController(  IStartJobUseCase StartJobUseCase,
                                StartJobPresenter StartJobPresenter, 
                                ICheckStatusUseCase CheckStatusUseCase, 
                                CheckStatusPresenter CheckStatusPresenter,
                                IGetJobLogUseCase GetJobLogUseCase,
                                GetJobLogPresenter GetJobLogPresenter,
                                IMapper mapper)
        {
            _startJobUseCase = StartJobUseCase;
            _startJobPresenter = StartJobPresenter;

            _checkStatusUseCase = CheckStatusUseCase;
            _checkStatusPresenter = CheckStatusPresenter;


            _getJobLogUseCase = GetJobLogUseCase;
            _getJobLogPresenter = GetJobLogPresenter;

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

        // GET api/Jobs/CheckStatus/{id}
        [HttpGet("CheckStatus/{jobId}")]
        public async Task<ActionResult> CheckStatusJobAsync(int jobId)
        {

            await _checkStatusUseCase.Handle(new CheckStatusUseCaseRequest(jobId), _checkStatusPresenter);

            return _checkStatusPresenter.ContentResult;
        }

        // GET api/Jobs/Logs/{id}
        [HttpGet("Logs/{jobId}")]
        public async Task<ActionResult> GetJobLogsAsync(int jobId)
        {

            await _getJobLogUseCase.Handle(new GetJobLogUseCaseRequest(jobId), _getJobLogPresenter);

            return _getJobLogPresenter.ContentResult;
        }


    }
}
