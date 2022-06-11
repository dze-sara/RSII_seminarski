using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentacar.Dto;
using Rentacar.Dto.Response;
using Rentacar.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.API.Controllers
{
    [Authorize]
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

        [HttpGet("models/{id}")]
        public async Task<IActionResult> GetModels([FromRoute] int id)
        {
            List<ModelBaseDto> result = await _filterService.GetModelsForMake(id);
            return Ok(result);
        }

        [HttpGet("make/{makeName}")]
        public async Task<IActionResult> GetModels([FromRoute] string makeName)
        {
            MakeBaseDto result = await _filterService.GetMake(makeName);
            return Ok(result);
        }

    }
}
