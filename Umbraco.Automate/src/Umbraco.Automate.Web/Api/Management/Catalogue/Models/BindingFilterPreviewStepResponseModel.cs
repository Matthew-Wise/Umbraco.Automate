namespace Umbraco.Automate.Web.Api.Management.Catalogue.Models;

/// <summary>
/// What one filter produced when previewing a filter chain.
/// </summary>
public sealed class BindingFilterPreviewStepResponseModel
{
    /// <summary>The value after the filter, as it would be written into the binding, or null when the filter failed.</summary>
    public string? Result { get; set; }

    /// <summary>Why the filter could not run, or null when it ran.</summary>
    public string? Error { get; set; }
}
