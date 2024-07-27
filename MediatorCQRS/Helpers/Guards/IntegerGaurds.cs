namespace MediatorCQRS.Helpers.Guards;

#pragma warning disable IDE0060 // Remove unused parameter
public static class IntegerGaurds
{
    public static int NegativeOrZero(this Guard guard, int value, string parameterName)
        => value <= 0
            ? throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be less than or equal zero.")
            : value;
    public static int Negative(this Guard guard, int value, string parameterName)
        => value < 0
            ? throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be less than zero.")
            : value;
    public static int Zero(this Guard guard, int value, string parameterName)
        => value == 0
            ? throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be equal to zero.")
            : value;
}

#pragma warning restore IDE0060 // Remove unused parameter