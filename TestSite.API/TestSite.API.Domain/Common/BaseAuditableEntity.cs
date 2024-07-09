using TestSite.API.Domain.Common.Interfaces;

namespace TestSite.API.Domain.Common;

public class BaseAuditableEntity : BaseEntity, IAuditableEntity
{
    /// <inheritdoc />
    public Guid? CreatedBy { get; set; }

    /// <inheritdoc />
    public DateTime? CreatedDate { get; set; }

    /// <inheritdoc />
    public Guid? UpdatedBy { get; set; }

    /// <inheritdoc />
    public DateTime? UpdatedDate { get; set; }
}