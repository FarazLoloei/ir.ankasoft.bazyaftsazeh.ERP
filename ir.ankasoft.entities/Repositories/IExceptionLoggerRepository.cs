using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities.Repositories
{
    public interface IExceptionLoggerRepository : IRepository<ExceptionLogger, long>
    {
        void Log(string controller, string action, string exceptionMessage, string paremeters, int stepCode = 0);
    }
}
