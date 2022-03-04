
using MediatR;
using RealEstateAPI.Model;
using RealEstateData.Commands;
using RealEstateData.Data_Access;

namespace RealEstateData.Handlers
{
    public class DeleteAgentByIdHandler : IRequestHandler<DeleteAgentByIdCommand, EstateAgent>
    {
        private readonly IAgentDataAccess _data;

        public DeleteAgentByIdHandler(IAgentDataAccess data)
        {
            _data = data;
        }

        public async Task<EstateAgent> Handle(DeleteAgentByIdCommand request, CancellationToken cancellationToken)
        {
            return await _data.DeleteAgentById(request.id);
        }
    }
}
