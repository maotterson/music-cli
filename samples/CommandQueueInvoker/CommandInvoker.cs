using CommandQueueInvoker.Commands;
using CommandQueueInvoker.Options;
using CommandQueueInvoker.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQueueInvoker;

internal class CommandInvoker
{
    private readonly Queue<(Type CommandType, Type CommandOptions, CommandInstruction Instruction)> _commandQueue = new();
    private ICommandOptions _originalOptions;

    private readonly ICommand _currentCommand;
    private readonly IResponse _previousResponse;

    public void Initialize(ICommandOptions options)
    {
        _originalOptions = options;
    }

    public void Enqueue((Type CommandType, Type CommandOptions, CommandInstruction Instruction) item)
    {
        _commandQueue.Enqueue(item);
    }

    public void InvokeCommand()
    {
        var currentItem = _commandQueue.Dequeue();
        var currentCommandType = currentItem.CommandType;
        var currentInstruction = currentItem.Instruction;
        var currentOptionsType = currentItem.CommandOptions;

        ICommand command;

        switch (currentInstruction)
        {
            case CommandInstruction.ORIGINAL:
                var options = _originalOptions;
                command = (ICommand)Activator.CreateInstance(currentCommandType, options);
                break;
            case CommandInstruction.PREVIOUS:
                var optionsFromResponseInterface = (ICanGetOptionsFromResponse<ICommandOptions,IResponse>)Activator.CreateInstance(currentOptionsType);
                options = optionsFromResponseInterface.Map(_previousResponse);
                command = (ICommand)Activator.CreateInstance(currentCommandType, options);
                break;
            case CommandInstruction.RETRY:
                options = _originalOptions;
                command = (ICommand)Activator.CreateInstance(currentCommandType, options);
                break;
            default:
                throw new();
        }
        var response = command.Execute();
    }

    public void Start()
    {
        while(_commandQueue.Count > 0)
        {
            InvokeCommand();
        }
    }
}
