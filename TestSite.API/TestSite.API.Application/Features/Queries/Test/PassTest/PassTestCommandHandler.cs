using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Application.Contracts.Test.PassTest;
using TestSite.API.Application.Interfaces;
using TestSite.API.Application.Models;
using TestSite.API.Domain.Entities;

namespace TestSite.API.Application.Features.Queries.Test.PassTest;

public class PassTestCommandHandler(IDbContext dbContext, IUserContext userContext) 
    : IRequestHandler<PassTestCommand, PassTestResponse>
{
    public async Task<PassTestResponse> Handle(PassTestCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();
        
        var userId = userContext.CurrentUserId;
        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException();

        var test = await dbContext.Tests
            .Include(t => t.Questions)
            .ThenInclude(q => q.Answers)
            .FirstOrDefaultAsync(t => t.Id == request.TestId, cancellationToken);
        if (test is null)
            throw new Exception("Тест не найден");

        var rightAnswers = 0;
        var questionResults = new List<UserAnswer>();

        foreach (var answer in request.UserAnswers)
        {
            var question = test.Questions.FirstOrDefault(q => q.Id == answer.QuestionId);
            if (question is null)
                continue;

            var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
            var isCorrect = correctAnswer != null && correctAnswer.Id == answer.Id;
            if (isCorrect)
                rightAnswers++;
            
            questionResults.Add(new UserAnswer
            {
                QuestionId = question.Id,
                AnswerOptionId = answer.Id,
                IsCorrect = isCorrect
            });
        }

        var points = 100 / request.UserAnswers.Count * rightAnswers;
        
        var testResult = new TestResult
        {
            Id = test.Id,
            UserId = userId,
            TimeTaken = request.TimeTaken,
            Points = points,
            UserAnswers = questionResults
        };
            
        dbContext.TestResults.Add(testResult);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new PassTestResponse
        {
            PassedTestModel = new PassedTestModel
            {
                UserAnswers = testResult.UserAnswers.Select(ua => new UserAnswerModel
                {
                    IsCorrect = ua.IsCorrect,
                    QuestionContent = ua.QuestionContent,
                    QuestionId = ua.QuestionId,
                    AnswerOptionId = ua.AnswerOptionId
                }).ToList(),
                Points = testResult.Points,
                TestId = testResult.Id,
                Title = testResult.Title,
                TimeTaken = testResult.TimeTaken,
                UserId = testResult.UserId
            }
        };
    }
}