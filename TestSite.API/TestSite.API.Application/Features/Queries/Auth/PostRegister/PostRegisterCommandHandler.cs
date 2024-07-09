using System.Net;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Localization;
using TestSite.API.Application.Interfaces;

namespace TestSite.API.Application.Features.Queries.Auth.PostRegister;

/// <summary>
/// Обработчик для <see cref="PostRegisterCommand"/>
/// </summary>
public class PostRegisterCommandHandler(
    UserManager<IdentityUser> userManager,
    IDbContext dbContext,
    IEmailSender emailSender,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<PostRegisterCommand, Unit>
{
    /// <inheritdoc />
    public async Task<Unit> Handle(PostRegisterCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();

        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is not null)
            throw new Exception();

        user = new IdentityUser
        {
            UserName = request.Username,
            Email = request.Email
        };

        var result = await userManager
            .CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new Exception();

        if (httpContextAccessor.HttpContext == null)
            throw new Exception();

        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        var encodedToken = WebUtility.UrlEncode(token);

        var scheme = httpContextAccessor.HttpContext.Request.Scheme;
        var host = httpContextAccessor.HttpContext.Request.Host.ToUriComponent();

        var confirmationLink = $"{scheme}://{host}/api/Auth/ConfirmEmail?userId={user.Id}&token={encodedToken}";

        await emailSender.SendEmailAsync(user.Email, "Подтверждение регистрации",
            $"Для завершения регистрации перейдите по ссылке: {confirmationLink}");

        return Unit.Value;
    }
}