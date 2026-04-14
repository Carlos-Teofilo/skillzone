using App.Domain.Shared.ValueObjects;

namespace App.Domain.Tests.Shared.ValueObjects;

public class TrackerTest
{
    [Fact]
    public void ShouldUpdateTracker()
    {
        // Arrange
        var createdAt = new DateTime(2024, 1, 1);
        var tracker = Tracker.Create(createdAt);

        var updatedAt = new DateTime(2024, 1, 2);

        // Act
        tracker.Update(updatedAt);

        // Assert
        Assert.Equal(updatedAt, tracker.UpdatedAt);
    }
}