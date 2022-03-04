using MediatR;
using RealEstateData.Queries;
using RealEstateAPI.Model;

namespace RealEstateData.Handlers
{
    public class GetAgentByIdHandler : IRequestHandler<GetAgentByIdQuery, EstateAgent>
    {
        private readonly IMediator _mediator;

        public GetAgentByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<EstateAgent> Handle(GetAgentByIdQuery request, CancellationToken cancellationToken)
        {
            var agents = await _mediator.Send(new GetAllAgentsListQuery());

            var agent = agents.FirstOrDefault(x => x.AgentId == request.Id);

            return agent;
        }
    }
}
