using TestSite.API.Domain.Common;

namespace TestSite.API.Domain.Entities;

/// <summary>
/// Ответ на вопрос
/// </summary>
public class AnswerOption : BaseEntity
{
    /// <summary>
    /// Текст ответа
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Правильный ответ или нет
    /// </summary>
    public bool IsCorrect { get; set; }
    
    /// <summary>
    /// Id вопроса, к которому относится ответ
    /// </summary>
    public Guid QuestionId { get; set; }

    /// <summary>
    /// Ссылка на на сам вопрос
    /// </summary>
    public Question Question { get; set; } = default!;
}