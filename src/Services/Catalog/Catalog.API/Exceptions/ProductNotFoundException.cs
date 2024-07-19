namespace Catalog.API.Exceptions;

public class ProductNotFoundException : Exception
{
	public ProductNotFoundException(Guid ıd) : base("Product not found")
	{
	}
}