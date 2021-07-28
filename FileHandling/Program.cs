using System;
using System.Globalization;
using System.IO;

namespace FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {           
            //Reads the source file
            Console.Write("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();

            try
            {
                //Creates the target file in a new folder
                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                string[] lines = File.ReadAllLines(sourceFilePath);
                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach(string line in lines)
                    {
                        string[] info = line.Split(",");
                        Product p = new Product(info[0], double.Parse(info[1], CultureInfo.InvariantCulture), int.Parse(info[2]));
                        sw.WriteLine(p.ToString().ToUpper());
                    }    
                }

                Console.WriteLine("File created successfully");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error has occurred: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An unexpected error has occurred! " + e.Message);
            }
        }
    }
}
