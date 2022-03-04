using MediatR;
using RealEstateAPI.Model;

namespace RealEstateData.Commands
{
    public record DeleteAgentByIdCommand(int id) : IRequest<EstateAgent>;

}
