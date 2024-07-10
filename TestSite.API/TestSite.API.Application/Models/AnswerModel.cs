namespace TestSite.API.Application.Models;

/// <summary>
/// dto ответа
/// </summary>
public class AnswerModel
{
    /// <summary>
    /// Текст ответа
    /// </summary>
    public string Text { get; set; } = default!;
    
    /// <summary>
    /// Правильный ответ или нет
    /// </summary>
    public bool IsCorrect { get; set; }
}