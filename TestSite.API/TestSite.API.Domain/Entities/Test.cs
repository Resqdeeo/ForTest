using Microsoft.AspNetCore.Identity;
using TestSite.API.Domain.Common;

namespace TestSite.API.Domain.Entities;

/// <summary>
/// Тест с вопросами
/// </summary>
public class Test : BaseAuditableEntity
{
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
    public List<Question> Questions { get; set; }

    /// <summary>
    /// Creator
    /// </summary>
    public IdentityUser Creator { get; set; }
}