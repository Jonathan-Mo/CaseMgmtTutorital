using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Features.Cases.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CaseMgmtAPI.Features.Cases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CasesController> _logger;

        public CasesController(IMediator mediator, ILogger<CasesController> logger)
        {
            _mediator = mediator;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<CasesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseDTO>>> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetCases.Query());

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a list of cases.", ex);
                return BadRequest();
            }
        }

        [Route("partial")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseDTO>>> GetPartial()
        {
            try
            {
                string myUrl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request);

                Microsoft.Extensions.Primitives.StringValues headerValues;
                //var filterFilter = string.Empty;
                //if (Request.Headers.TryGetValue("filter", out headerValues))
                //{
                //    filterFilter = headerValues.FirstOrDefault();
                //}

                int page;
                if (Request.Headers.TryGetValue("page", out headerValues))
                {
                    page = Int32.Parse(headerValues.FirstOrDefault());
                }
                else
                {
                    return BadRequest();
                }

                int size;
                if (Request.Headers.TryGetValue("size", out headerValues))
                {
                    size = Int32.Parse(headerValues.FirstOrDefault());
                }
                else
                {
                    return BadRequest();
                }

                int count;
                if (Request.Headers.TryGetValue("count", out headerValues))
                {
                    count = Int32.Parse(headerValues.FirstOrDefault());
                }
                else
                {
                    return BadRequest();
                }



                var totalResult = await _mediator.Send(new GetCases.Query());

                if (totalResult.Value == null)
                    return NoContent();

                ActionResult<IEnumerable<CaseDTO>> extractedResult = totalResult.Value.ToList().Skip((page - 1) * size).Take(size).ToList();

                return Ok(extractedResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a list of cases.", ex);
                return BadRequest();
            }
        }

        // GET api/<CasesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseDTO>> Get([FromRoute] int id)
        {
            try
            {

                var result = await _mediator.Send(new GetCasesById.Query(id));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a case by Id.", ex);
                return BadRequest();
            }
        }

        // POST api/<CasesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Case value)
        {
            try
            {

                var result = await _mediator.Send(new CreateCases.Command(value));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while creating a new case.", ex);
                return BadRequest();
            }
        }

        // PUT api/<CasesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Case value)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCasesById.Command(id, value));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while updating a case by ID.", ex);
                return BadRequest();
            }
        }

        // DELETE api/<CasesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var result = await _mediator.Send(new DeleteCaseById.Command(id));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while deleting a case by ID.", ex);
                return BadRequest();
            }
        }
    }
}
