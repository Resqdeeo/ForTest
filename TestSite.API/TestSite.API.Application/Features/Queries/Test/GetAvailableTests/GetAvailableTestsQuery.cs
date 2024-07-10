using MediatR;
using TestSite.API.Application.Contracts.Test.GetAvailableTests;

namespace TestSite.API.Application.Features.Queries.Test.GetAvailableTests;

/// <summary>
/// Запрос на получение <see cref="GetAvailableTests"/>
/// </summary>
public class GetAvailableTestsQuery : IRequest<GetAvailableTestsResponse>
{
}