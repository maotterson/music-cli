using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Services;

public interface ICommandQueue
{
    public void Enqueue(IValidRequest command);
    public IValidRequest Dequeue();
    public IValidRequest Peek();

    public int Count { get; }
}
