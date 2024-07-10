using TestSite.API.Domain.Entities;

namespace TestSite.API.Application.Models;

public class QuestionModel
{
    /// <summary>
    /// Описание (формулировка) вопроса
    /// </summary>
    public string Text { get; set; } = default!;

    /// <summary>
    /// Опции (варианты ответа)
    /// </summary>
    public List<AnswerModel> Answers { get; set; } = default!;
}