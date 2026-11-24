namespace Umbraco.Automate.Core.Bindings;

/// <summary>
/// What one filter produced in <see cref="BindingEvaluator.PreviewFilters"/>: either the value as
/// it would be written into a binding, or why the filter could not run.
/// </summary>
/// <param name="Result">The stringified value after the filter, or null when it failed.</param>
/// <param name="Error">Why the filter could not run, or null when it ran.</param>
internal sealed record BindingFilterPreviewStep(string? Result, string? Error);
