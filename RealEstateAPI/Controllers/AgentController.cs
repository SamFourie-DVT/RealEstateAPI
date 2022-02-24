using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        //connects the database
        private readonly DataContext _context;

        public AgentController(DataContext context)
        {
            _context = context;

        }

        //gets all the agents
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<EstateAgent>>> Get()
        {
            try
            {
                //gets all the agents in the database - EstateAgents
                return Ok(await _context.EstateAgents.ToListAsync());
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
                //gets the agent from the database and checks to see that it exists
                var agent = await _context.EstateAgents.FindAsync(Id);
                if (agent == null)
                    return BadRequest("Agent Not Found");
                //gets all the agents in the database - EstateAgents
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
                //ensuring that a valid first and last name has been entered.
                if (agentObject.FirstName == "" || agentObject.LastName == "")
                {
                    return BadRequest("First and last name must be entered.");
                }
                //ensures that the cell phone number is valid
                if (agentObject.CellPhone.Length != 10 || !agentObject.CellPhone.All(char.IsDigit))
                {
                    return BadRequest("Cell phone field must have 10 numbers.");
                }
                //adds the agent to the database
                _context.EstateAgents.Add(agentObject);
                await _context.SaveChangesAsync();

                //returns the updated agents in the database
                return Ok(await _context.EstateAgents.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Updates an agent by id
        [HttpPut("UpdateAgentById{id}")]
        public async Task<ActionResult<List<EstateAgent>>> UpdateAgent(EstateAgent agentObject, int id)
        {
            try
            {
                //assigns the agent and checks to make sure it exists
                var agents = await _context.EstateAgents.FindAsync(id);
                if (agents == null)
                    return BadRequest("Agent Not Found");

                //ensuring that a valid first and last name has been entered.
                if (agentObject.FirstName == "" || agentObject.LastName == "")
                {
                    return BadRequest("First and last name must be entered.");
                }
                //ensures that the cell phone number is valid
                if (agentObject.CellPhone.Length != 10 || !agentObject.CellPhone.All(char.IsDigit))
                {
                    return BadRequest("Cell phone field must have 10 numbers.");
                }

                //assigns the new values
                agents.FirstName = agentObject.FirstName;
                agents.LastName = agentObject.LastName;
                agents.CellPhone = agentObject.CellPhone;
                agents.CountryCode = agentObject.CountryCode;

                //saves the changes
                await _context.SaveChangesAsync();

                //returns all the agents in the database
                return Ok(await _context.EstateAgents.ToListAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Deletes the agent by Id
        [HttpDelete("DeleteAgentById{Id}")]
        public async Task<ActionResult<List<EstateAgent>>> DeleteAgent(int Id)
        {
            try
            {
                //assigns the agent and checks to make sure it exists
                var agent = await _context.EstateAgents.FindAsync(Id);
                if (agent == null)
                    return BadRequest("Agent Not Found");

                //deletes the agent
                _context.EstateAgents.Remove(agent);

                //saves the changes
                await _context.SaveChangesAsync();

                //returns all the agents in the database
                return Ok(await _context.EstateAgents.ToListAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
