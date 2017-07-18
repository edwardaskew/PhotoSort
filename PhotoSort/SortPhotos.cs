using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MetadataExtractor;
using PhotoSort;
namespace MainSort
{
    internal class Main
    {
        public static string[] ImportIndexFile(string indexFilePath)
        {
            string[] IndexFile = File.ReadAllLines(indexFilePath);
            return IndexFile;
        }
        public static Dictionary<string, List<string>> CreateFolders(string[] indexFileText, string finalLocationPath)
        {
            Dictionary<string, List<string>> SortDictionary = new Dictionary<string, List<string>>();
            foreach (string line in indexFileText)
            {
                List<string> dictionaryList = new List<string>();
                string[] paramiters = line.Split(',');
                string file = paramiters[3];
                string finalLocation = $"{finalLocationPath}\\{file}";
                if (!System.IO.Directory.Exists(finalLocation))
                {
                    System.IO.Directory.CreateDirectory(finalLocation);
                    Debug.WriteLine($"Created Folder at {finalLocation}");
                }
                else
                {
                    Debug.WriteLine($"Could not create folder at {finalLocation}");
                }
                SortDictionary.Add(file, dictionaryList);
            }
            SortDictionary.Add("Un-Sorted", new List<string>());
            return SortDictionary;
        }
        public static Dictionary<string, List<string>> SortImageDataToDictionary(Dictionary<string, List<string>> SortDictionary, string photoLocationPath, string[] indexFileText, Dictionary<string, List<DateTime>> sortFilter, ProgressBar sortProgress)
        {
            float totalProgress = 0;
            float currentProgress = 0;
            string[] numberOfImageFolders = System.IO.Directory.GetDirectories(photoLocationPath);//if there are multiple image folders, loop through them all
            foreach (string ImageFolder in numberOfImageFolders)
            {
                string[] SourceImages = System.IO.Directory.GetFiles(ImageFolder, "*.jpg");
                totalProgress = totalProgress + SourceImages.Count();
            }
            foreach (string imageFolder in numberOfImageFolders)
            {
                string[] sourceImages = System.IO.Directory.GetFiles(imageFolder, "*.jpg");
                foreach (string image in sourceImages)
                {
                    var imageDateTime = GetDateDigitized(image);
                    
                    foreach (var Iitem in sortFilter)
                    {
                        DateTime minDateTime = sortFilter[Iitem.Key][0];
                        DateTime maxDateTime = sortFilter[Iitem.Key][1];
                        string targetFolder = Iitem.Key;


                        if ((imageDateTime >= minDateTime) && (imageDateTime < maxDateTime))
                        {
                            SortDictionary[targetFolder].Add(image);
                            break;
                        }      
                    }
                    currentProgress++;
                    float progress = currentProgress / totalProgress * 100;
                    sortProgress.Value = (int) progress;
                    sortProgress.Update();
                }
            }
            return SortDictionary;
        }
        public static DateTime GetDateDigitized(string photoLocation)
        {
            string dateTimeDigitized = null;
            IEnumerable<MetadataExtractor.Directory> imageData = ImageMetadataReader.ReadMetadata(photoLocation);
            foreach (var tagType in imageData)
            {
                if (tagType.Name == "Exif SubIFD")
                {
                    foreach (var tag in tagType.Tags)
                    {
                        if (tag.Name == "Date/Time Digitized")
                        {
                            dateTimeDigitized = tag.Description;
                        }
                    }
                }
            }
            //date format attached to tag is not compatable with Convert.ToDateTime, the following code is to make it compatable
            DateTime ImageDate = DateTime.ParseExact(dateTimeDigitized, "yyyy:MM:dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return ImageDate;
        }
        public static Dictionary<string, List<DateTime>> CreateSortFilter(string[] indexFileText)
        {
            var SortFilter = new Dictionary<string, List<DateTime>>();
            foreach (var line in indexFileText)
            {
                string[] splitLine = line.Split(',');
                string targetFolder = splitLine[3];
                string buildMinDateTime = $"{splitLine[2]} {splitLine[0]}";
                string buildMaxDateTime = $"{splitLine[2]} {splitLine[1]}";
                DateTime minDateTime = DateTime.ParseExact(buildMinDateTime, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime maxDateTime = DateTime.ParseExact(buildMaxDateTime, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                
                SortFilter.Add(targetFolder, new List<DateTime>());
                SortFilter[targetFolder].Add(minDateTime);
                SortFilter[targetFolder].Add(maxDateTime);
            }
            return SortFilter;
        }
        public static void MoveFiles(Dictionary<string, List<string>> sortDictionary, string finalLocationPath, ProgressBar secondProgressBar)
        {
            //progress bar
            float numberOfFiles = sortDictionary.Count();
            float currentProgress = 0;
            foreach (var item in sortDictionary)
            {
                string targetFolder = item.Key;
                string saveFolder = $"{finalLocationPath}\\{targetFolder}";
                foreach (string image in sortDictionary[item.Key])
                {
                    //get the filename
                    var splitImageDir = image.Split('\\');
                    string filename = splitImageDir[4];
                    string saveFileDir = $"{saveFolder}\\{filename}";
                    if (System.IO.Directory.Exists(saveFolder))
                    {
                        System.IO.File.Copy(image, saveFileDir, true);
                    }
                    else
                    {
                        Debug.WriteLine($"Error! - {saveFolder} doesn't exist");
                    }

                }
                currentProgress++;
                float progress = currentProgress / numberOfFiles * 100;
                secondProgressBar.Value = (int) progress;
                secondProgressBar.Update();
            }
        }
        public static void TriggerFunctions(string indexFilePath, string photoLocationPath, string finalLocationPath, ProgressBar sortProgress, ProgressBar secondProgressBar)
        {
            string[] IndexFileText = ImportIndexFile(indexFilePath);
            var SortFilter = CreateSortFilter(IndexFileText);
            var SortDictionary = CreateFolders(IndexFileText, finalLocationPath);
            SortDictionary = SortImageDataToDictionary(SortDictionary, photoLocationPath, IndexFileText, SortFilter, sortProgress);
            MoveFiles(SortDictionary, finalLocationPath, secondProgressBar);
        }
    }
}

