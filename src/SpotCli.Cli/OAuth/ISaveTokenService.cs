﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.OAuth;

public interface ISaveTokenService
{
    public string Save(string token);
}
