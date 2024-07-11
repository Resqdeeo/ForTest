using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Application.Contracts.Test.GetTestById;
using TestSite.API.Application.Interfaces;
using TestSite.API.Application.Models;

namespace TestSite.API.Application.Features.Queries.Test.GetTestById;

public class GetTestByIdQueryHandler(IDbContext dbContext) : IRequestHandler<GetTestByIdQuery, GetTestByIdResponse>
{
    public async Task<GetTestByIdResponse> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();

        var test = await dbContext.Tests.
            Include(t => t.Questions).
            ThenInclude(q => q.Answers)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (test is null)
            throw new Exception();

        var questionModels = test.Questions.Select(q => new QuestionModel
        {
            Text = q.Text,
            Answers = q.Answers.Select(a => new AnswerModel
            {
                Text = a.Text,
                IsCorrect = a.IsCorrect
            }).ToList()
        }).ToList();

        return new GetTestByIdResponse
        {
            Id = test.Id,
            Title = test.Title,
            CreatorId = test.CreatedBy ?? "unknown",
            Description = test.Description,
            EndDate = test.EndDate,
            TimeLimit = test.TimeLimit,
            Questions = questionModels
        };
    }
}