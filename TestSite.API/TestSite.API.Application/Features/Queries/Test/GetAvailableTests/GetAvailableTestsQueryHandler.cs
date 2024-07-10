using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Application.Contracts.Test.GetAvailableTests;
using TestSite.API.Application.Interfaces;

namespace TestSite.API.Application.Features.Queries.Test.GetAvailableTests;

public class GetAvailableTestsQueryHandler(
    IDbContext _dbContext
    ) : IRequestHandler<GetAvailableTestsQuery, GetAvailableTestsResponse>
{
    public async Task<GetAvailableTestsResponse> Handle(
        GetAvailableTestsQuery request, 
        CancellationToken cancellationToken
        )
    {
        if (request is null)
            throw new Exception();
        
        var tests =  await _dbContext.Tests
            .Select(t => new GetAvailableTestsProp
            {
                Id = t.Id,
                Title = t.Title
            })
            .ToListAsync(cancellationToken);

        return new GetAvailableTestsResponse
        {
            Tests = tests
        };
    }
}