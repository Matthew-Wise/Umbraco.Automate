using System.ComponentModel.DataAnnotations;

namespace Umbraco.Automate.Web.Api.Management.Catalogue.Models;

/// <summary>
/// Request model for previewing a chain of binding filters on a sample value.
/// </summary>
public sealed class PreviewBindingFiltersRequestModel
{
    /// <summary>
    /// The sample value, as text. JSON object or array text is read as an object or list, the
    /// way a resolved binding path is. Null stands for a missing value.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>The filters, in the order they are applied.</summary>
    [Required]
    public List<BindingFilterInvocationRequestModel> Filters { get; set; } = [];
}

/// <summary>
/// One filter in a <see cref="PreviewBindingFiltersRequestModel"/>.
/// </summary>
public sealed class BindingFilterInvocationRequestModel
{
    /// <summary>The filter alias.</summary>
    [Required]
    public string Alias { get; set; } = string.Empty;

    /// <summary>The filter arguments, in order.</summary>
    [Required]
    public List<string> Args { get; set; } = [];
}
