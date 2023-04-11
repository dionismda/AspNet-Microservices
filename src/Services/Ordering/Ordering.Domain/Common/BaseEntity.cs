﻿namespace Ordering.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? LastModifiedBy { get; set; } = null;
    public DateTime? LastModifiedDate { get; set; } = null;
}
