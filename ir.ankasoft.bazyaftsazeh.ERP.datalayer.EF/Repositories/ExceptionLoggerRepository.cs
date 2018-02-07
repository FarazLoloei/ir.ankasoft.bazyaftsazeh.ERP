using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    public class ExceptionLoggerRepository : Repository<ExceptionLogger>, IExceptionLoggerRepository
    {
        public void Log(string controller, string action, string exceptionMessage, string paremeters, int stepCode = 0)
        {
            Add(new ExceptionLogger()
            {
                Controller = controller,
                Action = action,
                StepCode = stepCode,
                ExceptionMessage = exceptionMessage,
                Paremeters = paremeters
            });
        }
    }
}
