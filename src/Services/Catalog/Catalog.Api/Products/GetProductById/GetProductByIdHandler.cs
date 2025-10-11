

namespace Catalog.Api.Products.GetProductById;
public record GetProductByIdQuery(Guid ProductId) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product? Product);
public class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.ProductId);
        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }
        return new GetProductByIdResult(product);
    }
}
