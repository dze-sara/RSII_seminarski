using AutoMapper;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Entities;
using Rentacar.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> AddReview(ReviewDto review)
        {
            Review newReview = _mapper.Map<Review>(review);
            return await _reviewRepository.AddReview(newReview, review.BookingId);
        }

        public async Task<List<ReviewDto>> GetReviewsByModelId(int modelId)
        {
            return _mapper.Map<List<ReviewDto>>(await _reviewRepository.GetReviewsByModelId(modelId));
        }
    }
}
