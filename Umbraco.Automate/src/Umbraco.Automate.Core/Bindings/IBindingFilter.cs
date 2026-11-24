using Umbraco.Cms.Core.Composing;

namespace Umbraco.Automate.Core.Bindings;

/// <summary>
/// A chainable filter that transforms values in bindings.
/// Filters are applied via the pipe syntax: <c>${ path | filterAlias:arg1:arg2 }</c>.
/// </summary>
/// <remarks>
/// <see cref="Name"/>, <see cref="Description"/> and <see cref="Arguments"/> describe the filter to
/// the backoffice, which lists it in the binding editor. They have defaults, so a filter that only
/// implements <see cref="Alias"/> and <see cref="Apply"/> still shows up, under its alias.
/// </remarks>
public interface IBindingFilter : IDiscoverable
{
    /// <summary>
    /// Gets the alias used in bindings (e.g. "truncate", "lowercase").
    /// </summary>
    string Alias { get; }

    /// <summary>
    /// Gets the display name shown in the backoffice. Defaults to <see cref="Alias"/>.
    /// </summary>
    string Name => Alias;

    /// <summary>
    /// Gets an optional description of what the filter does, shown in the backoffice.
    /// </summary>
    string? Description => null;

    /// <summary>
    /// Gets the arguments the filter takes, in the order they are written after the alias.
    /// Defaults to none.
    /// </summary>
    IReadOnlyList<BindingFilterArgument> Arguments => [];

    /// <summary>
    /// Applies the filter to a value.
    /// </summary>
    /// <param name="value">The current value (may be null).</param>
    /// <param name="args">Arguments passed after the filter alias, split by colon.</param>
    /// <returns>The transformed value.</returns>
    object? Apply(object? value, string[] args);
}
