using MediatR;

namespace CarWashManager.Application.Mediators
{
    public class Mediator : IMediator, ISender
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetService(handlerType);

            var task = (Task<TResponse>)handler.GetType()
                .GetMethod("Handle")
                .Invoke(handler, new object[] { request, cancellationToken });

            return task;
        }

        Task ISender.Send<TRequest>(TRequest request, CancellationToken cancellationToken)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(Unit));
            var handler = _serviceProvider.GetService(handlerType);

            var task = (Task)handler.GetType()
                .GetMethod("Handle")
                .Invoke(handler, new object[] { request, cancellationToken });

            return task;
        }

        public Task<object?> Send(object request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
