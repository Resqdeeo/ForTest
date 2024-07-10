using MediatR;
using TestSite.API.Application.Contracts.Test.GetPassedTests;

namespace TestSite.API.Application.Features.Queries.Test.GetPassedTests;

public class GetPassedTestsQuery : IRequest<GetPassedTestsResponse>
{
}