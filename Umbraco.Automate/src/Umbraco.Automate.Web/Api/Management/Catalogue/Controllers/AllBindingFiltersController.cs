using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Automate.Core.Bindings;
using Umbraco.Automate.Web.Api.Management.Catalogue.Models;
using Umbraco.Cms.Core.Mapping;

namespace Umbraco.Automate.Web.Api.Management.Catalogue.Controllers;

/// <summary>
/// Gets all registered binding filters.
/// </summary>
[ApiVersion("1.0")]
public sealed class AllBindingFiltersController : CatalogueControllerBase
{
    private readonly BindingFilterCollection _filters;
    private readonly IUmbracoMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="AllBindingFiltersController"/> class.
    /// </summary>
    public AllBindingFiltersController(BindingFilterCollection filters, IUmbracoMapper mapper)
    {
        _filters = filters;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all registered binding filters with the arguments they take, ordered by name, so the
    /// binding editor can offer them without the author knowing the pipe syntax.
    /// </summary>
    [HttpGet("binding-filters")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(typeof(IEnumerable<BindingFilterItemResponseModel>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<BindingFilterItemResponseModel>> GetAllBindingFilters()
        => Ok(_mapper.MapEnumerable<IBindingFilter, BindingFilterItemResponseModel>(
            _filters.OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase)));
}
