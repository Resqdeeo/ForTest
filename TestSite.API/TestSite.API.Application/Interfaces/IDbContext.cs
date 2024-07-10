using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Domain.Entities;

namespace TestSite.API.Application.Interfaces;

public interface IDbContext
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<IdentityUser> Users { get; set; }
    
    /// <summary>
    /// Набор данных для таблицы "Tests", представляющей тесты.
    /// </summary>
    public DbSet<Test> Tests { get; set; }

    /// <summary>
    /// Набор данных для таблицы "AnswerOptions"
    /// </summary>
    public DbSet<AnswerOption> AnswerOptions { get; set; }

    /// <summary>
    /// Набор данных для таблицы "Questions", представляющей вопросы.
    /// </summary>
    public DbSet<Question> Questions { get; set; }

    /// <summary>
    /// Набор данных для таблицы Результаты тестов
    /// </summary>
    public DbSet<TestResult> TestResults { get; set; }
    
    /// <summary>
    /// Набор данных для таблицы Ответы пользователей
    /// </summary>
    public DbSet<UserAnswer> UserAnswers { get; set; }

    /// <summary>
    /// Метод сохранения
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}