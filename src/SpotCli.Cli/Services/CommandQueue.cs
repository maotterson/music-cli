using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Services;

public class CommandQueue : ICommandQueue
{
    private readonly Queue<IValidCommand> _queue = new();

    public int Count => _queue.Count;

    public IValidCommand Dequeue()
    {
        return _queue.Dequeue();
    }

    public void Enqueue(IValidCommand command)
    {
        _queue.Enqueue(command);
    }

    public IValidCommand Peek()
    {
        return _queue.Peek();
    }
}
