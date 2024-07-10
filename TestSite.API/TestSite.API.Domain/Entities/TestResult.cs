using TestSite.API.Domain.Common;

namespace TestSite.API.Domain.Entities;

/// <summary>
/// Прохождение теста пользователем
/// </summary>
public class TestResult : BaseEntity
{
    /// <summary>
    /// Название теста
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Ссылка на тест
    /// </summary>
    public Test Test { get; set; } = default!;

    /// <summary>
    /// ID пользователя
    /// </summary>
    public string UserId { get; set; } = default!;

    /// <summary>
    /// Дата прохождения
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Время, затраченное на прохождение теста
    /// </summary>
    public TimeSpan TimeTaken { get; set; }

    /// <summary>
    /// Баллы полученные за тест
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Список ответов пользователя
    /// </summary>
    public List<UserAnswer> UserAnswers { get; set; } = new();
}