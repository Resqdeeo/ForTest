using MediatR;
using Microsoft.AspNetCore.Identity;
using TestSite.API.Application.Contracts.User.GetUser;
using TestSite.API.Application.Interfaces;

namespace TestSite.API.Application.Features.Queries.User.GetUser;

/// <summary>
/// Обработчик для <see cref="GetUserQuery"/>
/// </summary>
public class GetUserQueryHandler(
    UserManager<IdentityUser> userManager,
    IUserContext userContext,
    IDbContext dbContext)
    : IRequestHandler<GetUserQuery, GetUserResponse>
{
    /// <inheritdoc cref="IRequestHandler{TRequest,TResponse}"/>
    public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var userId = userContext.CurrentUserId;

        if (userId is null)
            throw new Exception();

        var user = await userManager.FindByIdAsync(userId.ToString()!);

        if (user is null)
            throw new Exception();

        return new GetUserResponse
        {
            UserId = user.Id,
            Email = user.Email!,
            UserName = user.UserName!
        };
    }
}