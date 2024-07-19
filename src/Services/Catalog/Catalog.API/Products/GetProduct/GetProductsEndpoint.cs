namespace Catalog.API.Products.GetProduct;

//public record GetProductRequest();

public record GetProductResponse(IEnumerable<Product>Products);

public class GetProductsEndpoint : ICarterModule
{
	public async void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/products", async (ISender sender) =>
		{

			var result = await sender.Send(new GetProductsQuery());

			var response = result.Adapt<GetProductResponse>();

			return Results.Ok(response);
		})
		.WithName("GetProducts")
		.Produces<GetProductResponse>(StatusCodes.Status200OK)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Get Product")
		.WithDescription("Get Product");
	}

}

