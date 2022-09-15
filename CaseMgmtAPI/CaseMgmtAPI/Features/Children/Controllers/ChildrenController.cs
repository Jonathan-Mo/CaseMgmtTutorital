using CaseMgmtAPI.Domain.Entity;
using CaseMgmtAPI.Features.Cases.Handlers;
using CaseMgmtAPI.Features.Children.DTO;
using CaseMgmtAPI.Features.Children.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseMgmtAPI.Features.Children.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ChildrenController> _logger;

        public ChildrenController(IMediator mediator, ILogger<ChildrenController> logger)
        {
            _mediator = mediator;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<ChildrenController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildDTO>>> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetChildren.Query());

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a list of children.", ex);
                return BadRequest();
            }
        }

        // GET api/<ChildrenController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChildDTO>> Get([FromRoute] long id)
        {
            try
            {
                var result = await _mediator.Send(new GetChildrenById.Query(id));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting a child by Id.", ex);
                return BadRequest();
            }
        }

        // POST api/<ChildrenController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Child value)
        {
            try
            {
                var result = await _mediator.Send(new CreateChildren.Command(value));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while creating a child.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        // PUT api/<ChildrenController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Child value)
        {
            try
            {
                var result = await _mediator.Send(new UpdateChildrenById.Command(id, value));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while updating a child by ID.", ex);
                return BadRequest();
            }
        }

        // DELETE api/<ChildrenController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var result = await _mediator.Send(new DeleteChildById.Command(id));

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while deleting a child by Id.", ex);
                return BadRequest();
            }
        }
    }
}
