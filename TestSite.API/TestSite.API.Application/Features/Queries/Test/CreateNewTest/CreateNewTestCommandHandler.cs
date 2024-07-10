using MediatR;
using TestSite.API.Application.Contracts.Test.CreateNewTest;
using TestSite.API.Application.Interfaces;
using TestSite.API.Domain.Entities;

namespace TestSite.API.Application.Features.Queries.Test.CreateNewTest;

public class CreateNewTestCommandHandler : IRequestHandler<CreateNewTestCommand, CreateNewTestResponse>
{
    private IDbContext _context;

    public CreateNewTestCommandHandler(IDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateNewTestResponse> Handle(CreateNewTestCommand request, CancellationToken cancellationToken)
    {
        var test = new Domain.Entities.Test
        {
            Title = request.Title,
            Description = request.Description,
            EndDate = request.EndDate,
            TimeLimit = request.TimeLimit,
            Questions = request.Questions.Select(q => new Question
            {
                Text = q.Text,
                Answers = q.Answers.Select(a => new AnswerOption
                {
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).ToList()
        };

        _context.Tests.Add(test);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateNewTestResponse
        {
            TestId = test.Id,
            Message = "Тест был успешно создан"
        };
    }
}