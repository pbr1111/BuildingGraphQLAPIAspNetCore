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

        public async Task<List<ProductReview>> GetForProductAsync(int productId)
        {
            return await this.dbContext.ProductReviews
                .Where(r => r.Product.Id == productId)
                .ToListAsync();
        }
    }
}
