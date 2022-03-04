using MediatR;
using RealEstateAPI.Model;

namespace RealEstateData.Queries
{
    public record GetAllAgentsListQuery() : IRequest<List<EstateAgent>>;
   
}
