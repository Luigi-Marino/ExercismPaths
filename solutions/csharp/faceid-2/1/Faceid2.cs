public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        return obj.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
        => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        return obj.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    => HashCode.Combine(Email, FacialFeatures); 
}

public class Authenticator
{
    private HashSet<Identity> _identityHashSet = [];
    private readonly Identity _adminIdentity = new("admin@exerc.ism", new FacialFeatures("green", 0.9m)); 
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    => faceA.Equals(faceB);
    
    public bool IsAdmin(Identity identity)
    => identity.Equals(_adminIdentity);

    public bool Register(Identity identity)
    => _identityHashSet.Add(identity);

    public bool IsRegistered(Identity identity)
    => _identityHashSet.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB)
    => ReferenceEquals(identityA, identityB);
}
