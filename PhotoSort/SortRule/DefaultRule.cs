using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSort.SortRule
{
    public class DefaultRule: SortRuleBase
    {
        public DefaultRule()
        {
            OutputDirectory = "Unsorted";
        }

        public override bool ShouldContain(FileInfo image)
        {
            return true;
        }
    }
}
