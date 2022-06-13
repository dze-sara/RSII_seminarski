using Rentacar.Dto;
using Rentacar.Mobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private static string _baseUrl = HttpHelper.BaseUrl + "api/Reviews";

        public async Task<List<ReviewDto>> GetReviewsByModelId(int modelId)
        {
            return await HttpHelper.GetAsync<List<ReviewDto>>($"{_baseUrl}/{modelId}");
        }
        public async Task<bool> AddReview(ReviewDto review)
        {
            return await HttpHelper.PostAsync<bool, ReviewDto>(_baseUrl, review);
        }
    }
}
