using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Services;

public class RequestQueue : IRequestQueue
{
    private readonly Queue<IValidRequest> _queue = new();

    public int Count => _queue.Count;

    public IValidRequest Dequeue()
    {
        return _queue.Dequeue();
    }

    public void Enqueue(IValidRequest command)
    {
        _queue.Enqueue(command);
    }

    public IValidRequest Peek()
    {
        return _queue.Peek();
    }
}
