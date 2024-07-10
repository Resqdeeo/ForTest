using MediatR;
using TestSite.API.Application.Contracts.Test.CreateNewTest;

namespace TestSite.API.Application.Features.Queries.Test.CreateNewTest;

public class CreateNewTestCommand : CreateNewTestRequest, IRequest<CreateNewTestResponse>
{
    public CreateNewTestCommand(CreateNewTestRequest request) : base(request)
    {
    }
}