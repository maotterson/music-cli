﻿using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Services;

public interface IRequestQueue
{
    public void Enqueue(IValidRequest request);
    public IValidRequest Dequeue();
    public IValidRequest Peek();

    public int Count { get; }
}
