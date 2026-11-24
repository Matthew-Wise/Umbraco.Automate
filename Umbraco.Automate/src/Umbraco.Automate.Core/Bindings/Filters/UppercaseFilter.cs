namespace Umbraco.Automate.Core.Bindings.Filters;

/// <summary>
/// Converts a string to uppercase. Usage: <c>| uppercase</c>.
/// </summary>
internal sealed class UppercaseFilter : IBindingFilter
{
    public string Alias => "uppercase";

    public string Name => "Uppercase";

    public string? Description => "Converts text to upper case.";

    public object? Apply(object? value, string[] args)
        => value is string str ? str.ToUpperInvariant() : value;
}
