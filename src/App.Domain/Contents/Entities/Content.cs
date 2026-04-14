using Api.Models;
using App.Domain.Shared.Entities;
using App.Domain.Shared.Enums;
using App.Domain.Shared.ValueObjects;
using ContentType = App.Domain.Shared.Enums.ContentType;


namespace App.Domain.Entities;

public class Content :  Entity
{
    public string Name { get; }
    public string Description { get; }
    public Guid OwnerId { get; }
    public Guid? UserId { get; }
    public ContentType ContentType { get; }
    public Tracker Tracker { get; }
    public string? Tags { get; }
    
}
