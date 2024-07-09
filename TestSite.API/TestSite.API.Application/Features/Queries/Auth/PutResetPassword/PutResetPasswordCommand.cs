using MediatR;
using TestSite.API.Application.Contracts.Auth.PutResetPassword;

namespace TestSite.API.Application.Features.Queries.Auth.PutResetPassword;

public class PutResetPasswordCommand: PutResetPasswordRequest, IRequest<PutResetPasswordResponse>
{
    public PutResetPasswordCommand(PutResetPasswordRequest request)
        : base(request)
    {
    }
}