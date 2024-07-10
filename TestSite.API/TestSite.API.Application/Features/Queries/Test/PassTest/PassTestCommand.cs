using MediatR;
using TestSite.API.Application.Contracts.Test.PassTest;

namespace TestSite.API.Application.Features.Queries.Test.PassTest;

public class PassTestCommand : PassTestRequest, IRequest<PassTestResponse>
{
    public PassTestCommand(PassTestRequest request) : base(request)
    {
    }
}