using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Cases.DTO;
using CaseMgmtAPI.Features.Cases.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
