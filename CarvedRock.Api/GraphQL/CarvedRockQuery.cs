using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery: ObjectGraphType
    {
        public CarvedRockQuery(ProductRepository productRepository)
        {
            FieldAsync<ListGraphType<ProductType>>(
                "products", 
                resolve: async context => await productRepository.GetAllAsync()
            );
        }
    }
}
