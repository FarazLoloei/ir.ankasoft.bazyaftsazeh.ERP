using System;
using System.Linq;

namespace ir.ankasoft.tools.Anka
{
    public class EntityItemCodeGenerator
    {
        public EntityItemCodeGenerator(string currentItemCode)
        {
            CurrentItemCode = currentItemCode;
            NextItemCode = generateNextItemCode();
        }

        private string generateNextItemCode()
        {
            string[] codeFragments = CurrentItemCode.Split('-');
            if (codeFragments.Count() != 2) throw new Exception("CodeIsInvalid");
            string codeHeader = codeFragments[0], code = codeFragments[1];
            return string.Format("{0}-{1}",
                                 codeHeader,
                                 long.Parse(code) + 1);
        }

        public string generateNextItemCode(string currentItemCode)
        {
            CurrentItemCode = currentItemCode;
            NextItemCode = generateNextItemCode();
            return NextItemCode;
        }

        public string CurrentItemCode { get; set; }

        public string NextItemCode { get; set; }
    }
}