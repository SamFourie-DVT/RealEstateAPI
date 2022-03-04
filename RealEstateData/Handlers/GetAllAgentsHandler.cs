using MediatR;
using RealEstateData.Queries;
using RealEstateAPI.Model;
using RealEstateData.Data_Access;

namespace RealEstateData.Handlers
{
    public class GetAllAgentsHandler : IRequestHandler<GetAllAgentsListQuery, List<EstateAgent>>
    {
        private readonly IAgentDataAccess _data;

        public GetAllAgentsHandler(IAgentDataAccess data)
        {
            _data = data;
        }

        public async Task<List<EstateAgent>> Handle(GetAllAgentsListQuery request, CancellationToken cancellationToken)
        {
            var agents = await _data.GetAllAgents();
            return agents;
        }
    }
}
