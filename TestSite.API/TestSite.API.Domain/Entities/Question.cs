using TestSite.API.Domain.Common;

namespace TestSite.API.Domain.Entities;

/// <summary>
/// Вопрос из теста с ответами
/// </summary>
public class Question : BaseEntity
{
    /// <summary>
    /// Описание (формулировка) вопроса
    /// </summary>
    public string Text { get; set; } = default!;
    

    /// <summary>
    /// Опции (варианты ответа)
    /// </summary>
    public List<AnswerOption> Answers { get; set; } = default!;

    /// <summary>
    /// Id теста, к которому относится вопрос
    /// </summary>
    public Guid TestId { get; set; }

    /// <summary>
    /// Ссылка на тест
    /// </summary>
    public Test Test { get; set; } = default!;
}