using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.sandBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContextMenuItemRepository repo = new ContextMenuItemRepository();
            foreach (var item in repo.GetContextMenu("Party",false,true))
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
    }
}
