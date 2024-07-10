using MediatR;
using TestSite.API.Application.Contracts.Test.GetTestById;

namespace TestSite.API.Application.Features.Queries.Test.GetTestById;

public class GetTestByIdQuery : IRequest<GetTestByIdResponse>
{
    /// <summary>
    /// Id 
    /// </summary>
    public Guid Id { get; set; }

    public GetTestByIdQuery(Guid id)
    {
        Id = id;
    }
}