using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Application.Contracts.Test.GetTestPasses;
using TestSite.API.Application.Interfaces;
using TestSite.API.Application.Models;

namespace TestSite.API.Application.Features.Queries.Test.GetTestPasses;

public class GetTestPassesQueryHandler(IDbContext dbContext, IUserContext userContext) 
    : IRequestHandler<GetTestPassesQuery, GetTestPassesResponse>
{
    public async Task<GetTestPassesResponse> Handle(GetTestPassesQuery request, CancellationToken cancellationToken)
    {
        var testResults = await dbContext.TestResults
            .Where(tr => tr.Id == request.Id)
            .Include(tr => tr.UserId)
            .Include(tr => tr.Test)
            .Where(tr => tr.Test.CreatedBy.Equals(userContext.CurrentUserId))
            .Include(tr => tr.UserAnswers)
            .ToListAsync(cancellationToken);

        var testPasses = testResults.Select(tr => new PassedTestModel
        {
            TestId = tr.Id,
            UserId = tr.UserId,
            Title = tr.Title,
            Points = tr.Points,
            TimeTaken = tr.TimeTaken,
            UserAnswers = tr.UserAnswers.Select(ua => new UserAnswerModel
            {
                IsCorrect = ua.IsCorrect,
                AnswerOptionId = ua.AnswerOptionId,
                QuestionContent = ua.QuestionContent,
                QuestionId = ua.QuestionId
            }).ToList()
        }).ToList();

        return new GetTestPassesResponse
        {
            TestPasses = testPasses
        };
    }
}