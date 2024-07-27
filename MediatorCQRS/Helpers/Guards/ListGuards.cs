namespace MediatorCQRS.Helpers.Guards;

#pragma warning disable IDE0060 // Remove unused parameter

public static class ListGuards
{
    public static List<T> Empty<T>(this Guard guard, List<T> list, string parameterName)
        => list is null || list.Count == 0
            ? throw new ArgumentException($"{parameterName} cannot be null or empty.", parameterName)
            : list;
}

#pragma warning restore IDE0060 // Remove unused parameter