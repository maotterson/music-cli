﻿using SpotCli.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.Exceptions;

public class Response429Exception : ResponseCodeException
{
    private static readonly string RESPONSE_MESSAGE = "Rate limit exceeded, try waiting before performing additional commands.";
    public Response429Exception(IValidCommand command)
        : base($"{command.Description} unsuccessful. {RESPONSE_MESSAGE}.", 429, command)
    {
    }
}