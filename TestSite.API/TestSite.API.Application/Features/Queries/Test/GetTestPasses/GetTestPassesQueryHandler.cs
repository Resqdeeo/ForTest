using MediatR;
using TestSite.API.Application.Contracts.Test.GetPassedTests;
using TestSite.API.Application.Features.Queries.Test.GetPassedTests;
using TestSite.API.Application.Interfaces;

namespace TestSite.API.Application.Features.Queries.Test.GetTestPasses;

public class GetTestPassesQueryHandler(IDbContext dbContext, IUserContext userContext) 
    : IRequestHandler<GetPassedTestsQuery, GetPassedTestsResponse>
{
    public async Task<GetPassedTestsResponse> Handle(GetPassedTestsQuery request, CancellationToken cancellationToken)
    {
        var testResults = await dbContext.TestResults
            .Where(tr => tr.Id == request)
        
        return 
    }
}