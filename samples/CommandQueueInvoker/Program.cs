// Testing implementation of a CommandInvoker layer

using CommandQueueInvoker;
using CommandQueueInvoker.Commands;
using CommandQueueInvoker.Options;

CommandInvoker invoker = new();
ICommandOptions initialOptions = new FooOptions()
{
    Name = "Fred"
};

invoker.Initialize(initialOptions);
invoker.Enqueue((typeof(FooCommand), typeof(FooOptions), CommandInstruction.ORIGINAL));
invoker.Enqueue((typeof(BarCommand), typeof(BarOptions), CommandInstruction.PREVIOUS));

Console.WriteLine("Queue Full");

invoker.Start();