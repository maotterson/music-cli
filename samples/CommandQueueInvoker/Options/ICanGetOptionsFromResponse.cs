using CommandQueueInvoker.Commands;
using CommandQueueInvoker.Responses;

namespace CommandQueueInvoker.Options;

public interface ICanGetOptionsFromResponse<out T, in K> where T : ICommandOptions where K : IResponse
{
    public T Map(K response);
}
