using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateData.Commands;
using RealEstateData.Queries;


namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        //declares the variable which we would use for the MediatR
        private readonly IMediator _mediator;

        public AgentController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        //gets all the agents
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<EstateAgent>>> Get()
        {
            
            try
            {
                var agents = await _mediator.Send(new GetAllAgentsListQuery());
                return Ok(agents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Gets agent by Id
        [HttpGet("GetAgentById{Id}")]
        public async Task<ActionResult<List<EstateAgent>>> GetAgentById(int Id)
        {
            try
            {
                var agent = await _mediator.Send(new GetAgentByIdQuery(Id));
                if (agent == null)
                    return BadRequest("Agent Not Found.");

                return Ok(agent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //adds another agent to the database
        [HttpPost("Create")]
        public async Task<ActionResult<List<EstateAgent>>> AddAgent(EstateAgent agentObject)
        {
            try
            {
                if (agentObject.FirstName == "" || agentObject.LastName == "")
                {
                    return BadRequest("First and last name must be entered.");
                }

                if (agentObject.CellPhone.Length != 10 || !agentObject.CellPhone.All(char.IsDigit))
                {
                    return BadRequest("Cell phone field must have 10 numbers.");
                }

                var addAgent = new AddAgentCommand(agentObject);
                var agentAdded = await _mediator.Send(addAgent);

                return Ok(agentAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Updates an agent by id
        [HttpPut("UpdateAgentById{id}")]
        public async Task<ActionResult<EstateAgent>> UpdateAgent(EstateAgent agentObject, int id)
        {
            try
            {
                if (agentObject.FirstName == "" || agentObject.LastName == "")
                {
                    return BadRequest("First and last name must be entered.");
                }

                if (agentObject.CellPhone.Length != 10 || !agentObject.CellPhone.All(char.IsDigit))
                {
                    return BadRequest("Cell phone field must have 10 numbers.");
                }

                var updateAgent = new UpdateAgentByIdCommand(agentObject, id);
                var agentUpdated = await _mediator.Send(updateAgent);

                if (agentUpdated == null)
                    return BadRequest("Agent Not Found.");

                return Ok(agentUpdated);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Deletes the agent by Id
        [HttpDelete("DeleteAgentById{Id}")]
        public async Task<ActionResult<EstateAgent>> DeleteAgent(int Id)
        {
            try
            {
                var agent =  new DeleteAgentByIdCommand(Id);

                var deletedAgent = await _mediator.Send(agent);

                return Ok(deletedAgent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
