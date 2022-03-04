using RealEstateAPI.Model;

namespace RealEstateData.Data_Access
{
    public interface IAgentDataAccess
    {
        Task<EstateAgent> AddAgent(EstateAgent agentObject);
        Task<EstateAgent> DeleteAgentById(int id);
        Task<EstateAgent> GetAgentById(int id);
        Task<List<EstateAgent>> GetAllAgents();
        Task<EstateAgent> UpdateAgentById(EstateAgent agentObject, int id);
    }
}