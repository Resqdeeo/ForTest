using MediatR;
using TestSite.API.Application.Contracts.Auth.PostLogin;

namespace TestSite.API.Application.Features.Queries.Auth.PostLogin;

public class PostLoginCommand : PostLoginRequest, IRequest<PostLoginResponse>
{
    public PostLoginCommand(PostLoginRequest request)
        : base(request)
    {
    }
}