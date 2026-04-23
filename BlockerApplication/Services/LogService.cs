using BlockerCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockerApplication.Services
{
    public class LogService
    {
        private readonly List<Log> _logs = new();
        public void AddLog(Log log)
        {
            _logs.Add(log);
        }
        public List<Log> GetAll()
        {
            return _logs;
        }
    }
}
