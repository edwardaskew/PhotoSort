using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSort.SortRule
{
    public class IndexFileSortRule : SortRuleBase
    {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public IndexFileSortRule(string indexFileLine)
        {
            var parameters = indexFileLine.Split(',');
            _start = DateTime.ParseExact($"{parameters[2]} {parameters[0]}", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            _end = DateTime.ParseExact($"{parameters[2]} {parameters[1]}", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            OutputDirectory = string.Join(",", parameters.Skip(3));
        }

        public override bool ShouldContain(FileInfo image)
        {
            var digitizedDate = ExifExtractor.GetDigitizedDate(image);
            return digitizedDate >= _start && digitizedDate < _end;
        }
    }
}
