using MediatR;
using TestSite.API.Application.Contracts.User.GetUser;

namespace TestSite.API.Application.Features.Queries.User.GetUser;

/// <summary>
/// Запрос на получение <see cref="GetUserResponse"/>
/// </summary>
public class GetUserQuery : IRequest<GetUserResponse>
{
}