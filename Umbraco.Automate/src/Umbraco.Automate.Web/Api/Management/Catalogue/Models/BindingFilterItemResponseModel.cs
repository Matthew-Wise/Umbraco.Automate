using System.ComponentModel.DataAnnotations;
using Umbraco.Automate.Core.Bindings;

namespace Umbraco.Automate.Web.Api.Management.Catalogue.Models;

/// <summary>
/// Response model for a registered binding filter.
/// </summary>
public sealed class BindingFilterItemResponseModel
{
    /// <summary>The alias written after the pipe in a binding (e.g. "truncate").</summary>
    [Required]
    public string Alias { get; set; } = string.Empty;

    /// <summary>The display name.</summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>Optional description of what the filter does.</summary>
    public string? Description { get; set; }

    /// <summary>The arguments the filter takes, in the order they are written.</summary>
    [Required]
    public List<BindingFilterArgumentResponseModel> Arguments { get; set; } = [];
}

/// <summary>
/// Response model for one argument of a binding filter.
/// </summary>
public sealed class BindingFilterArgumentResponseModel
{
    /// <summary>The display name.</summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>Optional description of the argument.</summary>
    public string? Description { get; set; }

    /// <summary>Optional example value for the input's placeholder.</summary>
    public string? Placeholder { get; set; }

    /// <summary>Whether the filter needs a value for this argument.</summary>
    public bool IsRequired { get; set; }

    /// <summary>The kind of value the argument takes.</summary>
    public BindingFilterArgumentType Type { get; set; }
}
