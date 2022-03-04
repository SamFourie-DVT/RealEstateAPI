using MediatR;
using RealEstateAPI.Model;
using RealEstateData.Commands;
using RealEstateData.Data_Access;

namespace RealEstateData.Handlers
{
    public class AddAgentHandler : IRequestHandler<AddAgentCommand, EstateAgent>
    {
        private readonly IAgentDataAccess _data;

        public AddAgentHandler(IAgentDataAccess data)
        {
            _data = data;
        }

        public async Task<EstateAgent> Handle(AddAgentCommand request, CancellationToken cancellationToken)
        {
            return await _data.AddAgent(request.agentObject);
        }
    }
}
