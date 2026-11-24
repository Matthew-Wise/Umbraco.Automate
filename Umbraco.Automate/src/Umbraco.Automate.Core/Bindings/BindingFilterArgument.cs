namespace Umbraco.Automate.Core.Bindings;

/// <summary>
/// Describes one argument of an <see cref="IBindingFilter"/>, in the order it is written after
/// the filter alias (<c>| truncate:100:...</c>). The backoffice uses it to render an input for
/// the argument, so authors can add filters without knowing the syntax.
/// </summary>
public sealed class BindingFilterArgument
{
    /// <summary>
    /// Gets the display name of the argument (e.g. "Length").
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Gets an optional description shown next to the argument's input.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Gets an optional example value shown as the input's placeholder.
    /// </summary>
    public string? Placeholder { get; init; }

    /// <summary>
    /// Gets a value indicating whether the filter needs a value for this argument to do anything.
    /// </summary>
    public bool IsRequired { get; init; }

    /// <summary>
    /// Gets the kind of value the argument takes. Arguments are always written as text in the
    /// binding; this only drives how the backoffice validates the input.
    /// </summary>
    public BindingFilterArgumentType Type { get; init; } = BindingFilterArgumentType.Text;
}

/// <summary>
/// The kind of value a <see cref="BindingFilterArgument"/> takes.
/// </summary>
public enum BindingFilterArgumentType
{
    /// <summary>Any text.</summary>
    Text,

    /// <summary>A whole number.</summary>
    Integer,
}
