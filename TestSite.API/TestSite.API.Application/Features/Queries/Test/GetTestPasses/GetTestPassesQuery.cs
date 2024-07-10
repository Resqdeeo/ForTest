using MediatR;
using TestSite.API.Application.Contracts.Test.GetTestPasses;

namespace TestSite.API.Application.Features.Queries.Test.GetTestPasses;

public class GetTestPassesQuery : IRequest<GetTestPassesResponse>
{
    /// <summary>
    /// Id теста
    /// </summary>
    public Guid Id { get; set; }


    public GetTestPassesQuery(Guid id)
    {
        Id = id;
    }
}