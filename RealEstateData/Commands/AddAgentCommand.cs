using MediatR;
using RealEstateAPI.Model;

namespace RealEstateData.Commands
{
    public record AddAgentCommand(EstateAgent agentObject) : IRequest<EstateAgent>;

}
