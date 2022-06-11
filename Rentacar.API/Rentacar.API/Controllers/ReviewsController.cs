using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentacar.Dto;
using Rentacar.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{modelId}")]
        public async Task<IActionResult> GetReviewsByModelId([FromRoute] int modelId)
        {
            List<ReviewDto> registeredUser = await _reviewService.GetReviewsByModelId(modelId);
            return Ok(registeredUser);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDto addReviewRequest)
        {
            bool reviewAdded = await _reviewService.AddReview(addReviewRequest);
            return Ok(reviewAdded);
        }
    }
}
