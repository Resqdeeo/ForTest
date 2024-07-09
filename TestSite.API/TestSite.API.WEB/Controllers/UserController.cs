using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestSite.API.Application.Contracts.User.GetUser;
using TestSite.API.Application.Contracts.User.GetUserById;
using TestSite.API.Application.Features.Queries.User.GetUser;
using TestSite.API.Application.Features.Queries.User.GetUserById;

namespace TestSite.API.WEB.Controllers;

/// <summary>
/// Контроллер отвечающий за действия с аккаунтом
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mediator">Медиатор из библиотеки MediatR</param>
    public UserController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Запрос текущего пользователя
    /// </summary>
    /// <returns>GetUserResponse(Id, Email, UserName, Roles, UserPhotoId)</returns>
    [HttpGet("GetUser")]
    public async Task<GetUserResponse> GetUser(CancellationToken cancellationToken)
        => await _mediator.Send(new GetUserQuery(), cancellationToken);

    /// <summary>
    /// Запрос пользователя по ИД
    /// </summary>
    /// <returns>GetUserResponse(Id, UserName, FirstName, LastName, Patronymic, CountryId)</returns>
    [AllowAnonymous]
    [HttpGet("GetUserInfoById/{id:guid}")]
    public async Task<GetUserByIdResponse> GetUserInfoById(string id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
}