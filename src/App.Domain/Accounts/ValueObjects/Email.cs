using System.Text.RegularExpressions;
using App.Domain.Shared.ValueObjects;

namespace App.Domain.Accounts.ValueObjects;

public sealed partial record Email : ValueObject
{
    #region Constants

    public const int MinLength = 6;
    public const int MaxLength = 160;
    public const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    #endregion
    
    #region Properties
    
    public string Address { get; }
    
    #endregion

    #region Constructor

    private Email(string address)
    {
        Address = address;
    }
    
    #endregion

    #region Factory

    public static Email Create(string address)
    {
        if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            throw new Exception("Email cannot be null or empty");
        if(!EmailRegex().IsMatch(address))
            throw new Exception("Email invalid format");
        
        address = address.Trim().ToLower();

        return new Email(address);
    }

    #endregion

    #region Overrides

    public override string ToString() => Address;

    #endregion

    #region Operators

    public static implicit operator string(Email email) => email.ToString();

    #endregion
    
    #region Other
    
    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
    
    #endregion
}