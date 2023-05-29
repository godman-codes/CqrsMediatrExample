using CqrsMediatrExample.Commands;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommands, bool>
    {
        private readonly FakeDataStore _fakeDataStore;

        public UpdateProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public Task<bool> Handle(UpdateProductCommands request, CancellationToken cancellationToken)
        {
            return _fakeDataStore.UpdateProduct(request.Product);
        }
    }
}
