namespace App.Domain.Shared.ValueObjects;

public record Tracker : ValueObject
{
    
    #region Properties
    
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set; }

    #endregion

    #region Constructors

    private Tracker()
    {
    }

    private Tracker(DateTime createdAt, DateTime? updatedAt)
    {
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    #endregion
    
    #region Factories

    public static Tracker Create(DateTime createdAt, DateTime? updatedAt = null)
    {
        return new Tracker(createdAt, updatedAt);
    }
    
    #endregion

    #region Methods

    public void Update(DateTime updatedAt) 
        => UpdatedAt = updatedAt;
    
    #endregion
}