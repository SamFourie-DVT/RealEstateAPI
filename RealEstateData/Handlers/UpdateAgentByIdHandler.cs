using MediatR;
using RealEstateAPI.Model;
using RealEstateData.Commands;
using RealEstateData.Data_Access;

namespace RealEstateData.Handlers
{
    public class UpdateAgentByIdHandler : IRequestHandler<UpdateAgentByIdCommand, EstateAgent>
    {
        private readonly IAgentDataAccess _data;

        public UpdateAgentByIdHandler(IAgentDataAccess data)
        {
            _data = data;
        }

        public async Task<EstateAgent> Handle(UpdateAgentByIdCommand request, CancellationToken cancellationToken)
        {
            return await _data.UpdateAgentById(request.agentObject, request.id);
        }
    }
}
