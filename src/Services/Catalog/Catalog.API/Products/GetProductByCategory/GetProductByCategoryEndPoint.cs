
using Catalog.API.Products.GetProduct;
using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.GetProductByCategory;
//public record GetProductByIdRequest();
public record GetProductByCategoryResponse(Product Product);
public class GetProductByCategoryEndPoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
		{
			var result = await sender.Send(new GetProductsByCategoryQuery(category));

			var response = result.Adapt <GetProductByCategoryResponse>();

			return Results.Ok(response);
		})
		.WithName("GetProductByCategory")
		.Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Get Product By Category")
		.WithDescription("Get Product By Category");
	}
}
