using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestSite.API.Application.Contracts.Auth.GetConfirmEmail;
using TestSite.API.Application.Contracts.Auth.PostForgotPassword;
using TestSite.API.Application.Contracts.Auth.PostLogin;
using TestSite.API.Application.Contracts.Auth.PostRegister;
using TestSite.API.Application.Contracts.Auth.PutResetPassword;
using TestSite.API.Application.Features.Queries.Auth.GetConfirmEmail;
using TestSite.API.Application.Features.Queries.Auth.PostForgotPassword;
using TestSite.API.Application.Features.Queries.Auth.PostLogin;
using TestSite.API.Application.Features.Queries.Auth.PostLogout;
using TestSite.API.Application.Features.Queries.Auth.PostRegister;
using TestSite.API.Application.Features.Queries.Auth.PutResetPassword;
using TestSite.API.Application.Models;

namespace TestSite.API.WEB.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class AuthController(IMediator mediator, FrontendSettings frontendSettings, ILogger<AuthController> logger) : ControllerBase
{
    /// <summary>
    /// Логин
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("Login")]
    public async Task<PostLoginResponse> Login(PostLoginRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Received Login request.");
        return await mediator.Send(new PostLoginCommand(request), cancellationToken);
    }

    /// <summary>
    /// Регистрация
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("Register")]
    public async Task Register([FromBody] PostRegisterRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Received Register request.");
        await mediator.Send(new PostRegisterCommand(request), cancellationToken);
    }

    /// <summary>
    /// Забыл пароль
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("ForgotPassword")]
    public async Task ForgotPassword([FromBody] PostForgotPasswordRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Received Forgot Password request.");
        await mediator.Send(new PostForgotPasswordCommand(request), cancellationToken);
    }

    /// <summary>
    /// Сбросить пароль
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("ResetPassword")]
    public async Task<PutResetPasswordResponse> ResetPassword([FromBody] PutResetPasswordRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Received Reset Password request.");
        return await mediator.Send(new PutResetPasswordCommand(request), cancellationToken);
    }

    /// <summary>
    /// Подтвердить email
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("ConfirmEmail")]
    public async Task<RedirectResult> ConfirmEmail([FromQuery] GetConfirmEmailRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Received a Email Confirmation request.");
        var result = await mediator.Send(new GetConfirmEmailQuery(request), cancellationToken);

        var errorMessage = "";
        if (result is { IsSucceed: false, Error: not null })
            errorMessage = string.Join(", ", result.Error);

        return Redirect(result.IsSucceed
            ? $"{frontendSettings.BaseUrl}/email-confirmed?success=true"
            : $"{frontendSettings.BaseUrl}/email-confirmed?success=false&message={Uri.EscapeDataString(errorMessage)}");
    }

    /// <summary>
    /// Выход
    /// </summary>
    /// <param name="cancellationToken"></param>
    [Authorize]
    [HttpDelete("Logout")]
    public async Task Logout(CancellationToken cancellationToken)
    {
        logger.LogInformation("Received a Logoung request.");
        await mediator.Send(new DeleteLogoutCommand(), cancellationToken);
    }
}