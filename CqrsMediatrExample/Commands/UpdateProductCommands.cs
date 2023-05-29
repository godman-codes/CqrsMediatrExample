using MediatR;

namespace CqrsMediatrExample.Commands
{
    public record UpdateProductCommands(Product Product) : IRequest<bool>;
}
