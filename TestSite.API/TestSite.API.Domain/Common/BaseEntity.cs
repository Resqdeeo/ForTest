using TestSite.API.Domain.Common.Interfaces;

namespace TestSite.API.Domain.Common;

public class BaseEntity : IEntity
{
    /// <inheritdoc />
    public Guid Id { get; set; }
}