using Rentacar.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetReviewsByModelId(int modelId);
        Task<bool> AddReview(ReviewDto review);
    }
}
