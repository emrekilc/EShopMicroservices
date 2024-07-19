

namespace Catalog.API.Products.GetProduct;

public record GetProductsQuery() : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product>Products);
internal class GetProductsQueryHandler
	(IDocumentSession session,ILogger<GetProductsQueryHandler>logger)
	: IQueryHandler<GetProductsQuery, GetProductsResult>
{
	public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
	{
		logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}",query);
		var products = await session.Query<Product>()
			.ToListAsync(cancellationToken);

		return new GetProductsResult(products);
		//async method to handle getinng products 
	}
}

