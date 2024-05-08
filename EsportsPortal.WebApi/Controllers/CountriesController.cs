using EsportsPortal.Services.References.Dto;
using EsportsPortal.Services.References.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[Route("api/countries")]
[ApiController]
public class CountriesController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<CountryListItem>> GetCountries(CancellationToken cancellationToken)
    {
        return await sender.Send(new GetCountriesQuery(), cancellationToken);
    }
}
