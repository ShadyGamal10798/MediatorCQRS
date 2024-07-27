namespace MediatorCQRS.Helpers.Guards;

#pragma warning disable IDE0060 // Remove unused parameter

public static class GenericGaurds
{
    public static T Default<T>(this Guard guard, T value, string parameterName)
    => value!.Equals(default(T))
        ? throw new ArgumentException($"{parameterName} cannot be equal to {default(T)}.", parameterName)
        : value;

    public static T NullOrDefault<T>(this Guard guard, T value, string parameterName)
    => value is null || value!.Equals(default(T))
        ? throw new ArgumentException($"{parameterName} cannot be null or equal to {default(T)}.", parameterName)
        : value;
    public static T Null<T>(this Guard guard, T value, string parameterName)
    => value is null
        ? throw new ArgumentException($"{parameterName} cannot be null.", parameterName)
        : value;
}

#pragma warning restore IDE0060 // Remove unused parameter
