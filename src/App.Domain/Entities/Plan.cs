using Api.Models.Enums;

namespace App.Domain;

public class Plan
{
    public int Id { get; set; }

    public User User { get; set; } = null!;
    public Guid? UserId { get; set; }

    public bool? IsOwner { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public string Description { get; set; }

    public int DurationInMonths { get; set; }

    public DateTime? DueDate { get; set; }

    public PlanStatus Status { get; set; } = PlanStatus.Pending;

    public IEnumerable<PlanStatusHistory> StatusHistory { get; set; }
        = new List<PlanStatusHistory>();

    public DateTime? UpdatedAt { get; set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}