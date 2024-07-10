using TestSite.API.Application.Models;

namespace TestSite.API.Application.Contracts.Test.CreateNewTest;

public class CreateNewTestRequest
{
    /// <summary>
    /// Название теста
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Дата окончания доступа к тесту
    /// </summary>
    public DateTime? EndDate { get; set; }
    
    /// <summary>
    /// Время на прохождение теста
    /// </summary>
    public TimeSpan? TimeLimit { get; set; }
    
    /// <summary>
    /// Вопросы
    /// </summary>
    public List<QuestionModel> Questions { get; set; }

    /// <summary>
    /// Creator
    /// </summary>
    public string CreatorId { get; set; }
    
    public CreateNewTestRequest() { }

    public CreateNewTestRequest(CreateNewTestRequest request)
    {
        Title = request.Title;
        Description = request.Description;
        EndDate = request.EndDate;
        TimeLimit = request.TimeLimit;
        Questions = request.Questions;
        CreatorId = request.CreatorId;
    }
}