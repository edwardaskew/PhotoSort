using System;
using System.Windows.Forms;

namespace PhotoSort
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PhotoSortGUI());
        }
        //initalise variables
        
        
    }
    public class SortClass
    {
        public void initiateSort(string IndexFilePath, string PhotoLocationPath, string SortedLocationPath)
        {

        }
    }
}
