public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static void EnsureSameCurrency(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
            throw new ArgumentException();
    }

    // TODO: implement equality operators
    public static bool operator == (CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount == b.amount;
    }

    public static bool operator != (CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount != b.amount;
    }
    
    // TODO: implement comparison operators
    public static bool operator > (CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount > b.amount;
    } 
    
    public static bool operator < (CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount < b.amount;
    } 
        
    // TODO: implement arithmetic operators
    public static CurrencyAmount operator + (CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator - (CurrencyAmount a, CurrencyAmount b)
     {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator * (CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount * b.amount, a.currency);
    }

    public static CurrencyAmount operator / (CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount / b.amount, a.currency);
    }

    // TODO: implement type conversion operators
    public static implicit operator decimal (CurrencyAmount a)
        => (decimal)(a.amount);

    public static implicit operator double (CurrencyAmount a)
        => (double)(a.amount);
}
