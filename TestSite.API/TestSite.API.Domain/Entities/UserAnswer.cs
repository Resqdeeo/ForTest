using TestSite.API.Domain.Common;

namespace TestSite.API.Domain.Entities;

/// <summary>
/// Ответ пользователя на вопрос
/// </summary>
public class UserAnswer : BaseEntity
{
    /// <summary>
    /// ID вопроса
    /// </summary>
    public Guid QuestionId { get; set; }
    
    /// <summary>
    /// Текст вопроса
    /// </summary>
    public string QuestionContent { get; set; } = default!;

    /// <summary>
    /// Ссылка на вопрос
    /// </summary>
    public Question Question { get; set; } = default!;

    /// <summary>
    /// ID выбранного ответа
    /// </summary>
    public Guid AnswerOptionId { get; set; }

    /// <summary>
    /// Ссылка на выбранный ответ
    /// </summary>
    public AnswerOption AnswerOption { get; set; } = default!;

    /// <summary>
    /// ID результата теста
    /// </summary>
    public Guid TestResultId { get; set; }

    /// <summary>
    /// Ссылка на результат теста
    /// </summary>
    public TestResult TestResult { get; set; } = default!;

    /// <summary>
    /// Правильный ли оказался ответ на вопрос или нет
    /// </summary>
    public bool IsCorrect { get; set; }
}