﻿
using Catalog.API.Products.UpdateProduct;
using FluentValidation;

namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
	public DeleteProductCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
	}
}

internal class DeleteProductCommandHandler
	(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
	: ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
	public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
	{
		logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", command);
		session.Delete<Product>(command.Id);
		await session.SaveChangesAsync(cancellationToken);

		return new DeleteProductResult(true);
	}
}