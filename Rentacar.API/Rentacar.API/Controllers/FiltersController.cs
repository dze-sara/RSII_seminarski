using Microsoft.AspNetCore.Mvc;
using Rentacar.Dto.Response;
using Rentacar.Services.Interfaces;
using System.Threading.Tasks;

namespace Rentacar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IFilterService _filterService;

        public FiltersController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilterLookups()
        {
            FilterLookupsDto result = await _filterService.GetFilterLookups();
            return Ok(result);
        }
    }
}
