using Rentacar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsByModelId(int modelId);
        Task<bool> AddReview(Review addReview, int bookingId);
    }
}
