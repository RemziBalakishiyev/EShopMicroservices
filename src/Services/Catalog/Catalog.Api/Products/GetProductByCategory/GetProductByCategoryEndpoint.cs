
namespace Catalog.Api.Products.GetProductByCategory;

//public record GetProductByCategoryRequest(string Category);
public record GetProductByCategoryResponse(IEnumerable<Product> Products);
public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var query = new GetProductByCategoryQuery(category);
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductByCategoryResponse>();
            return Results.Ok(response);
        }).Accepts<GetProductByCategoryResponse>("application/json")
          .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
          .WithName("GetProductByCategory")
          .WithTags("Products");
    }
}
