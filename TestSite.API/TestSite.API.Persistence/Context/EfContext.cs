using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Application.Interfaces;
using TestSite.API.Domain.Entities;

namespace TestSite.API.Persistence.Context;

public class EfContext : IdentityDbContext, IDbContext
{
    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public EfContext()
    {
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public EfContext(DbContextOptions options)
        : base(options)
    {
    }
    
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка отношений между таблицей "Tests" и таблицей "Questions".
        modelBuilder.Entity<Test>()
            .HasMany(t => t.Questions)
            .WithOne(q => q.Test)
            .HasForeignKey(q => q.TestId);

        // Настройка отношений между таблицей "Tests" и таблицей "Users".
        modelBuilder.Entity<Test>()
            .HasOne(t => t.Creator)
            .WithMany()
            .HasForeignKey(t => t.CreatedBy);

        // Настройка отношений между таблицей "Questions" и таблицей "Answers".
        modelBuilder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

        base.OnModelCreating(modelBuilder);
    }
}