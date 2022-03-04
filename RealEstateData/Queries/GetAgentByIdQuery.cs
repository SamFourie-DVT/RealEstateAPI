using MediatR;
using RealEstateAPI.Model;

namespace RealEstateData.Queries
{
    public record GetAgentByIdQuery(int Id) : IRequest<EstateAgent>;

}
