using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories
{
    public class ProductReviewRepository
    {
        private readonly CarvedRockDbContext dbContext;

        public ProductReviewRepository(CarvedRockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ILookup<int, ProductReview>> GetForProductAsync(IEnumerable<int> productIds)
        {
            var reviews = await this.dbContext.ProductReviews
                .Where(r => productIds.Contains(r.Product.Id))
                .ToListAsync();
            return reviews.ToLookup(r => r.ProductId);
        }
    }
}
