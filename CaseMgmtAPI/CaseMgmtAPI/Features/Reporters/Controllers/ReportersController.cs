using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Features.Children.Handlers;
using CaseMgmtAPI.Features.Reporters.DTO;
using CaseMgmtAPI.Features.Reporters.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseMgmtAPI.Features.Reporters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReportersController> _logger;

        public ReportersController(IMediator mediator, ILogger<ReportersController> logger)
        {
            _mediator = mediator;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<ReportersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporterDTO>>> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetReporters.Query());

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a list of reporters.", ex);
                return BadRequest();
            }
        }

        // GET api/<ReportersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReporterDTO>> Get([FromRoute] long id)
        {
            try
            {
                var result = await _mediator.Send(new GetReportersById.Query(id));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a reporter by Id.", ex);
                return BadRequest();
            }
        }

        // POST api/<ReportersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reporter value)
        {
            try
            {
                var result = await _mediator.Send(new CreateReporters.Command(value));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while creating a new reporter.", ex);
                return BadRequest();
            }
        }

        // PUT api/<ReportersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Reporter value)
        {
            try
            {
                var result = await _mediator.Send(new UpdateReportersById.Command(id, value));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while updating a reporter by Id.", ex);
                return BadRequest();
            }
        }

        // DELETE api/<ReportersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {

                var result = await _mediator.Send(new DeleteReporterById.Command(id));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while deleting a reporter by Id.", ex);
                return BadRequest();
            }
        }
    }
}
