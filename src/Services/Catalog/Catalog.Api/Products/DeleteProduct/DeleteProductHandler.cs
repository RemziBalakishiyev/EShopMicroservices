namespace Catalog.Api.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
public record DeleteProductResult(Guid Id);

public class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling DeleteProductCommand for Product ID: {ProductId}", command.Id);
        
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        
        if (product == null)
        {
            logger.LogWarning("Product with ID {ProductId} not found", command.Id);
            throw new InvalidOperationException($"Product with ID {command.Id} not found");
        }
        
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("Product with ID {ProductId} deleted successfully", command.Id);
        return new DeleteProductResult(command.Id);
    }
}

