namespace App.Domain.Accounts.ValueObjects;

public sealed record PasswordHash
{
    #region Constants

    public const int MinLength = 8;
    public const int MaxLength = 18;

    #endregion
    
    #region Properties

    public string Password { get; }
    public string Hash { get; }
    
    #endregion
    
    #region Constructor

    private PasswordHash(string password, string hash)
    {
        Password = password;
        Hash = hash;
    }
    
    #endregion
    
    #region Factories

    public static PasswordHash Create(string password)
    {
        var hash = "";

        return new PasswordHash(password, hash);
    }

    #endregion
}