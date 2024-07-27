namespace MediatorCQRS.Helpers.Guards;

#pragma warning disable IDE0060 // Remove unused parameter

public static class StringGaurds
{
    public static string NullOrEmpty(this Guard guard, string value, string parameterName)
    => string.IsNullOrEmpty(value)
        ? throw new ArgumentNullException(parameterName, $"{parameterName} cannot be null or empty.")
        : value;
}

#pragma warning restore IDE0060 // Remove unused parameter