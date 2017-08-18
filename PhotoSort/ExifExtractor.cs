using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace PhotoSort
{
    internal static class ExifExtractor
    {
        public static DateTime GetDigitizedDate(FileInfo image)
        {
            var exifDirs = ImageMetadataReader.ReadMetadata(image.OpenRead()).OfType<ExifSubIfdDirectory>();
        }
    }
}
