namespace TestSite.API.Application.Models;

public class UserAnswerModel
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
    /// ID выбранного ответа
    /// </summary>
    public Guid AnswerOptionId { get; set; }
    
    /// <summary>
    /// Правильный ли ответ или нет
    /// </summary>
    public bool IsCorrect { get; set; }
}