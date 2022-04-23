using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Services;

public interface ICommandQueue
{
    public void Enqueue(IValidCommand command);
    public IValidCommand Dequeue();
    public IValidCommand Peek();
}
