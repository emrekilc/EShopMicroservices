
namespace Catalog.API.Products.GetProduct;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;
public record GetProductsByCategoryResult(IEnumerable<Product> Products);
internal class GetProductsByCategoryQueryHandler
	(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger)
	: IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
	public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
	{
		logger.LogInformation("GetProductsByCategoryQueryHandler.Handle called with {@Query}", query);
		var products = await session.Query<Product>()
			.Where(p=>p.Category.Contains(query.Category))
			.ToListAsync(cancellationToken);

		return new GetProductsByCategoryResult(products);
		//async method to handle getinng products 
	}
}

