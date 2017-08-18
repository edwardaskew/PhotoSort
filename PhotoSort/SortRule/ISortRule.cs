using System.Collections.Generic;
using System.IO;

namespace PhotoSort.SortRule
{
    public interface ISortRule: IEnumerable<FileInfo>
    {
        bool ShouldContain(FileInfo image);

        string OutputDirectory { get; }

        void AddImage(FileInfo image);
    }
}