using App.Domain.Accounts.Enums;
using App.Domain.Accounts.ValueObjects;
using App.Domain.Shared.Entities;
using App.Domain.Shared.Extensions;
using App.Domain.Shared.ValueObjects;

namespace App.Domain.Accounts.Entities;

public sealed class User : Entity
{
    #region Properties
    
    public string Name { get; }
    public Email Email { get; }
    public PasswordHash PasswordHash { get; }
    public string Slug { get; }
    public Role Role { get; }
    public bool IsActive { get; }
    public Tracker Tracker { get; }

    #endregion

    #region Constructor

    private User(
        string name,
        Email email,
        PasswordHash passwordHash,
        string slug,
        Role role,
        bool isActive,
        Tracker tracker
    )
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Slug = slug;
        Role = role;
        IsActive = isActive;
        Tracker = tracker;
    }
        
    #endregion
    
    #region Factories
    private static User CreateInternal(string name, string email, string password, Role role)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty or null.", nameof(name));

        name = name.Trim();

        return new User(
            name: name,
            email: Email.Create(email),
            passwordHash: PasswordHash.Create(password),
            slug: $"{name.Slugify()}-{Guid.NewGuid():N}",
            role: role,
            isActive: true,
            tracker: Tracker.Create(DateTime.UtcNow)
        );
    }

    public static User Create(string name, string email, string password)
        => CreateInternal(name, email, password, Role.User);

    public static User CreateAdmin(string name, string email, string password)
        => CreateInternal(name, email, password, Role.Administrator);

    #endregion
}
