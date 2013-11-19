﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManager
{
    class Program
    {
        enum Music
        {
            mp3
        };
        enum Photo
        {
            jpeg,
            jpg,
            png
        };
        enum Documents
        {
            pdf,
            txt
        };
        enum Programs
        {
            exe,
            msi,
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Starting it up");
            Console.WriteLine("---------------------------------------");
            DateTime currentDay = DateTime.Today; //formwat with "MM-dd-yyyy"
            int count = 0;

            string sourceDir, destDir;
            sourceDir = "C:\\Users\\GoodBoy\\Downloads\\";

            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            List<FileInfo> filesDoc = new List<FileInfo>();
            List<FileInfo> filesMusic = new List<FileInfo>();
            List<FileInfo> filesPics = new List<FileInfo>();
            List<FileInfo> filesExe = new List<FileInfo>();
            List<FileInfo> filesEtc = new List<FileInfo>();
            FileInfo[] tempCurrentFiles = dir.GetFiles();
            List<FileInfo> currentFiles = tempCurrentFiles.Cast<FileInfo>().ToList();

            //Sanitize from other files. Remove .ini and .db

            Console.WriteLine("Files in Directory");
            Console.WriteLine("---------------------------------------");
            foreach (FileInfo oneF in currentFiles)
            {
                Console.WriteLine(oneF.ToString());
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Sorting Files");
            Console.WriteLine("---------------------------------------");
            count = currentFiles.Count();
            Console.WriteLine(count.ToString());

            //Get extension has period in
            Console.ReadLine();
            string fileExt;
            #region File Sorting
            foreach (FileInfo file in currentFiles)
            {
                //Removing the period from extension
                fileExt = file.Extension.ToString();
                fileExt = fileExt.Remove(0, 1);
                //Console.WriteLine(fileExt);
                //Console.ReadLine();

                if (Enum.IsDefined(typeof(Music), fileExt))
                {
                    filesMusic.Add(file);
                    //        currentFiles.Remove(file);
                }
                else if (Enum.IsDefined(typeof(Photo), fileExt))
                {
                    filesPics.Add(file);
                    //      currentFiles.Remove(file);
                }
                else if (Enum.IsDefined(typeof(Documents), fileExt))
                {
                    filesDoc.Add(file);
                    //    currentFiles.Remove(file);
                }
                else if (Enum.IsDefined(typeof(Programs), fileExt))
                {
                    filesExe.Add(file);
                    //  currentFiles.Remove(file);
                }
                // dont sort these files
                else
                {
                    filesEtc.Add(file);
                }
            }
            #endregion

            #region Place in Proper Folder
            //if folder exists

            #endregion
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("All Done");
            Console.ReadLine();
        }
    }
}
