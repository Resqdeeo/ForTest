namespace TestSite.API.Domain.Entities;

/// <summary>
/// Типы возможных вопросов
/// </summary>
public enum QuestionType
{
    /// <summary>
    /// обычный вопрос с одним ответом
    /// </summary>
    SingleChoice,
    
    /// <summary>
    /// Вопрос с множеством вариантов правильных ответов
    /// </summary>
    MultipleChoice,
    
    /// <summary>
    /// Вопрос с расширенным ответом
    /// </summary>
    ExtendedAnswer,
    
    /// <summary>
    /// Вопрос с правильным порядком
    /// </summary>
    Ordered
}