using CqrsMediatrExample.Commands;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly FakeDataStore _fakeDataStore;

        public DeleteProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return _fakeDataStore.DeleteProduct(request.Id);
        }
    }
}
