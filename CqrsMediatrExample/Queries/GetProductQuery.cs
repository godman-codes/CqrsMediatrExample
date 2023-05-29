using MediatR;

namespace CqrsMediatrExample.Queries
{
    public record GetProductQuery : IRequest<IEnumerable<Product>>;
}
