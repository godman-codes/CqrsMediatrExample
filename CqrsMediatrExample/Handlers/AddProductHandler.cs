using CqrsMediatrExample.Commands;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDateStore;

        public AddProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDateStore = fakeDataStore;
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDateStore.AddProduct(request.Product);
            return request.Product;
        }
    }
}
