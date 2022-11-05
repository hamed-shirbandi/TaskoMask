using Grpc.Core;
using Grpc.Core.Interceptors;

namespace TaskoMask.BuildingBlocks.Web.MVC.Exceptions
{
    /// <summary>
    /// Global exception handler for gRPC services
    /// </summary>
    public class GrpcExceptionInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception exception)
            {
                throw new RpcException(new Status(StatusCode.Cancelled, exception.Message));
            }
        }
    }
}
