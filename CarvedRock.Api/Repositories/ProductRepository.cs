using System.Collections.Generic;
using System.Threading.Tasks;
using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories
{
    public class ProductRepository
    {
        private readonly CarvedRockDbContext dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await this.dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetOne(int productId)
        {
            return await this.dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }
    }
}
