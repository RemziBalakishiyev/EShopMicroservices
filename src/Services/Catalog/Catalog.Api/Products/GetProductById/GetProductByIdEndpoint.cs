
namespace Catalog.Api.Products.GetProductById;
//public record GetProductByIdRequest(Guid ProductId);
public record GetProductByIdResponse(Product Product);
public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id,ISender sender) =>
        {
            var query = new GetProductByIdQuery(id);
            var result = await sender.Send(query);
            if (result.Product is null)
            {
                return Results.NotFound(new { Message = $"Product with ID {id} was not found." });
            }
            var response = result.Adapt<GetProductByIdResponse>();
            return Results.Ok(response);
        }).Accepts<GetProductByIdResponse>("application/json")
          .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .WithName("GetProductById")
          .WithTags("Products");
    }
}
