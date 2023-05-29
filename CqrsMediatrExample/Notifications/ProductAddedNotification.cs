using MediatR;

namespace CqrsMediatrExample.Notifications
{
    public record ProductAddedNotification(Product product) : INotification;
    
}
