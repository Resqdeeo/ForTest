using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Application.Contracts.User.GetUserById;
using TestSite.API.Application.Interfaces;

namespace TestSite.API.Application.Features.Queries.User.GetUserById;

/// <summary>
/// Обработчик для <see cref="GetUserByIdQuery"/>
/// </summary>
public class GetUserByIdQueryHandler(IDbContext dbContext)
    : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    /// <inheritdoc />
    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();

        var userInfoFromDb = await dbContext.Users
                                 .FirstOrDefaultAsync(x => x.Id == request.Id || x.Id == request.Id,
                                     cancellationToken)
                             ?? throw new Exception();

        return new GetUserByIdResponse
        {
            Id = userInfoFromDb.Id,
            UserName = userInfoFromDb.UserName ?? "Unknown",
        };
    }
}