using MediatR;
using TestSite.API.Application.Contracts.Auth.PostForgotPassword;

namespace TestSite.API.Application.Features.Queries.Auth.PostForgotPassword;

public class PostForgotPasswordCommand : PostForgotPasswordRequest, IRequest<Unit>
{
    public PostForgotPasswordCommand(PostForgotPasswordRequest request)
        : base(request)
    {
    }
}