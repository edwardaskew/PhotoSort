using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSort.SortRule
{
    public abstract class SortRuleBase: ISortRule
    {
        protected readonly ICollection<FileInfo> Images = new List<FileInfo>();

        public abstract bool ShouldContain(FileInfo image);
        public string OutputDirectory { get; protected set; }

        public void AddImage(FileInfo item)
        {
            Images.Add(item);
        }

        public void CopyImages(DirectoryInfo outputRoot)
        {
            var outputDir = outputRoot.GetDirectories(OutputDirectory).SingleOrDefault() ??
                            outputRoot.CreateSubdirectory(OutputDirectory);
            foreach (var image in Images)
            {
                image.CopyTo(Path.Combine(outputDir.FullName, image.Name));
            }
        }

        public IEnumerator<FileInfo> GetEnumerator()
        {
            return Images.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) Images).GetEnumerator();
        }
    }
}
