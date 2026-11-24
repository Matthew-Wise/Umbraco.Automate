using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Automate.Core.Bindings;
using Umbraco.Automate.Web.Api.Management.Catalogue.Models;

namespace Umbraco.Automate.Web.Api.Management.Catalogue.Controllers;

/// <summary>
/// Previews a chain of binding filters on a sample value.
/// </summary>
[ApiVersion("1.0")]
public sealed class PreviewBindingFiltersController : CatalogueControllerBase
{
    private readonly BindingEvaluator _evaluator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PreviewBindingFiltersController"/> class.
    /// </summary>
    public PreviewBindingFiltersController(BindingEvaluator evaluator) => _evaluator = evaluator;

    /// <summary>
    /// Runs a sample value through the given filters with the same filter implementations a run
    /// uses, and returns what each filter produced. The list stops at the first filter that does
    /// not exist or cannot be applied, whose entry carries the error.
    /// </summary>
    /// <param name="requestModel">The sample value and the filters to apply.</param>
    [HttpPost("binding-filters/preview")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(typeof(IEnumerable<BindingFilterPreviewStepResponseModel>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<BindingFilterPreviewStepResponseModel>> PreviewBindingFilters(
        PreviewBindingFiltersRequestModel requestModel)
    {
        var steps = _evaluator.PreviewFilters(
            requestModel.Value,
            requestModel.Filters.Select(f => (f.Alias.Trim(), f.Args.Select(a => a.Trim()).ToArray())));

        return Ok(steps
            .Select(s => new BindingFilterPreviewStepResponseModel { Result = s.Result, Error = s.Error })
            .ToList());
    }
}
