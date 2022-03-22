using Microsoft.EntityFrameworkCore;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly RentacarContext _context;

        public ReviewRepository(RentacarContext context)
        {
            _context = context;
        }

        public async Task<bool> AddReview(Review addReview)
        {
            await _context.Review.AddAsync(addReview);

            return true;
        }

        public async Task<List<Review>> GetReviewsByModelId(int modelId)
        {
            return await _context.Review.Where(x => x.ModelId == modelId)
                           .OrderByDescending(x => x.ReviewId)
                           .ToListAsync();
        }
    }
}
