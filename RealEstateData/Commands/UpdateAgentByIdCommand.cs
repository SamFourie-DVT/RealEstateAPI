using MediatR;
using RealEstateAPI.Model;

namespace RealEstateData.Commands
{
    public record UpdateAgentByIdCommand(EstateAgent agentObject, int id) : IRequest<EstateAgent>;

}
