using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Data;
using RealEstateAPI.Model;

namespace RealEstateData.Data_Access
{
    public class AgentDataAccess : IAgentDataAccess
    {
        //connects the database
        private readonly DataContext _context;

        public AgentDataAccess(DataContext context)
        {
            _context = context;

        }

        public async Task<List<EstateAgent>> GetAllAgents()
        {
            //gets all the agents in the database
            var agentsInDB = await _context.EstateAgents.ToListAsync();
            return agentsInDB;
        }

        public async Task<EstateAgent> GetAgentById(int id)
        {
            //finds the agent by the given id
            var agent = await _context.EstateAgents.FindAsync(id);
            return agent;
        }

        public async Task<EstateAgent> AddAgent(EstateAgent agentObject)
        {
            //adds the agent to the database
            _context.EstateAgents.Add(agentObject);
            await _context.SaveChangesAsync();

            //returns all the agents in the database
            return agentObject;
        }

        public async Task<EstateAgent> UpdateAgentById(EstateAgent agentObject, int id)
        {
            var agent = await _context.EstateAgents.FindAsync(id);

            if (agent == null)
            {
                return agent;
            }

            //assigns the new values
            agent.FirstName = agentObject.FirstName;
            agent.LastName = agentObject.LastName;
            agent.CellPhone = agentObject.CellPhone;
            agent.CountryCode = agentObject.CountryCode;

            //saves the changes
            await _context.SaveChangesAsync();

            return agent;
        }

        public async Task<EstateAgent> DeleteAgentById(int id)
        {
            //assigns the agent
            var agent = await _context.EstateAgents.FindAsync(id);

            //deletes the agent
            _context.EstateAgents.Remove(agent);

            //saves the changes
            await _context.SaveChangesAsync();

            return agent;
        }
    }
}
