using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestSite.API.Application.Interfaces;

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
}