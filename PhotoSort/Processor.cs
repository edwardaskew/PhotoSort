using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using PhotoSort.SortRule;

namespace PhotoSort
{
    internal class Processor
    {

        public event Action<int> SortProgress = i => { };
        public event Action<int> CopyProgress = i => { }; 

        private readonly IEnumerable<ISortRule> _rules;
        public Processor(IEnumerable<string> indexLines)
        {
            _rules = indexLines.Select(l => (ISortRule)new IndexFileSortRule(l)).Concat(new []{ new DefaultRule() });
        }

        public void Sort(DirectoryInfo imageDirectory)
        {
            var images = imageDirectory.GetDirectories().SelectMany(d => d.GetFiles("*.jpg"));
            var sortedImages = 0;

            foreach (var image in images)
            {             
                var directory = _rules.First(d => d.ShouldContain(image));
                directory.AddImage(image);
              
                ++sortedImages;
                SortProgress(sortedImages * 100 / images.Count());
            }
        }

        public void CopyImages(DirectoryInfo outputRoot)
        {
            var copiedImages = 0;
            var totalImages = _rules.Sum(r => r.Count());

            foreach (var rule in _rules)
            {
                var outputDirectory = outputRoot.GetDirectories(rule.OutputDirectory).SingleOrDefault() ??
                                      outputRoot.CreateSubdirectory(rule.OutputDirectory);
                foreach (var image in rule)
                {
                    
                    image.CopyTo(Path.Combine(outputDirectory.FullName, image.Name));
                    ++copiedImages;
                    CopyProgress(copiedImages * 100 / totalImages);
                }             
            }
        }
    }
}

