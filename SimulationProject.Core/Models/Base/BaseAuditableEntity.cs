﻿namespace SimulationProject.Core.Models.Base;

public class BaseAuditableEntity : BaseEntity
{
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
