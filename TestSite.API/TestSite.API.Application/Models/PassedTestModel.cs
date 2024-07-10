namespace TestSite.API.Application.Models;

/// <summary>
/// Модель пройденного теста
/// </summary>
public class PassedTestModel
{
    /// <summary>
    /// Id теста
    /// </summary>
    public Guid TestId { get; set; }

    /// <summary>
    /// Id пользователя, проходившего тест
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Название теста
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Дата прохождения
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Время потраченное на прохождение
    /// </summary>
    public TimeSpan TimeTaken { get; set; }
    
    /// <summary>
    /// Баллы полученные в результате тестирования
    /// </summary>
    public int Points { get; set; }
    
    /// <summary>
    /// Ответы пользователя
    /// </summary>
    public List<UserAnswerModel> UserAnswers { get; set; }
}