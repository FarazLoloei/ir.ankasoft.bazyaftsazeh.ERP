using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories;
using System;

namespace ir.ankasoft.sandBox
{
    public class Program
    {
        private static void Main(string[] args)
        {
            ContextMenuItemRepository repo = new ContextMenuItemRepository();
            foreach (var item in repo.GetContextMenu("Party", false, true))
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
    }
}