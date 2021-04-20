﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Services.Logging
{
    public interface ILoggerManager
    {

        public void LogInfo(string message);
        public void LogWarn(string message);
        public void LogDebug(string message);
        public void LogError(string message);
    }
}
