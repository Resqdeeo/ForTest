using TestSite.API.Application.Models;
using TestSite.API.Domain.Entities;

namespace TestSite.API.Application.Contracts.Test.GetTestById;

public class GetTestByIdResponse
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id
    /// </summary>
    public string CreatorId { get; set; }

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
}