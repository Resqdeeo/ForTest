using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Application.Contracts.Test.GetPassedTests;
using TestSite.API.Application.Interfaces;
using TestSite.API.Application.Models;

namespace TestSite.API.Application.Features.Queries.Test.GetPassedTests;

public class GetPassedTestsQueryHandler(IDbContext dbContext, IUserContext userContext) : IRequestHandler<GetPassedTestsQuery, GetPassedTestsResponse>
{
    public async Task<GetPassedTestsResponse> Handle(GetPassedTestsQuery request, CancellationToken cancellationToken)
    {
        var testResults = await dbContext.TestResults
            .Where(tr => tr.UserId.Equals(userContext.CurrentUserId))
            .Include(tr => tr.UserAnswers)
            .ToListAsync(cancellationToken);

        var passedTests = testResults.Select(tr => new PassedTestModel
        {
            TestId = tr.Id,
            Title = tr.Title,
            Date = tr.Date,
            TimeTaken = tr.TimeTaken,
            Points = tr.Points,
            UserId = userContext.CurrentUserId,
            UserAnswers = tr.UserAnswers.Select(ua => new UserAnswerModel
            {
                QuestionId = ua.QuestionId,
                QuestionContent = ua.QuestionContent,
                AnswerOptionId = ua.AnswerOptionId,
                IsCorrect = ua.IsCorrect
            }).ToList()
        }).ToList();

        return new GetPassedTestsResponse
        {
            PassedTests = passedTests
        };
    }
}