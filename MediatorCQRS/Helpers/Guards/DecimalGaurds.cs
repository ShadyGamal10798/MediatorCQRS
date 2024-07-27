namespace MediatorCQRS.Helpers.Guards;

#pragma warning disable IDE0060 // Remove unused parameter

public static class DecimalGaurds
{
    public static decimal NegativeOrZero(this Guard guard, decimal value, string parameterName)
        => value <= 0
            ? throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be less than or equal zero.")
            : value;
    public static decimal Negative(this Guard guard, decimal value, string parameterName)
        => value < 0
            ? throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be less than zero.")
            : value;
    public static decimal Zero(this Guard guard, decimal value, string parameterName)
        => value == 0
            ? throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be equal to zero.")
            : value;
    public static decimal GreaterThan(this Guard guard, decimal value, decimal limit, string parameterName)
        => value > limit
            ? throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} should be less than {limit}")
            : value;
}

#pragma warning restore IDE0060 // Remove unused parameter