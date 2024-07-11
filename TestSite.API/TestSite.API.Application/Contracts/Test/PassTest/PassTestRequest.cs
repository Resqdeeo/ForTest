using TestSite.API.Domain.Entities;

namespace TestSite.API.Application.Contracts.Test.PassTest;

public class PassTestRequest
{
    /// <summary>
    /// ID теста
    /// </summary>
    public Guid TestId { get; set; }

    /// <summary>
    /// ID пользователя
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Время затраченное на тест
    /// </summary>
    public TimeSpan TimeTaken { get; set; }

    /// <summary>
    /// Ответы пользователя
    /// </summary>
    public List<AnswerOption> UserAnswers { get; set; }

    public PassTestRequest()
    {
    }

    public PassTestRequest(PassTestRequest request)
    {
        TestId = request.TestId;
        UserId = request.UserId;
        UserAnswers = request.UserAnswers;
        TimeTaken = request.TimeTaken;
    }
}