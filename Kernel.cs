using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace Cosmos3d
{
    public class Kernel : Sys.Kernel
    {
        string drivess = @"0:\\";
        Sys.FileSystem.CosmosVFS fs;

        protected override void BeforeRun()
        {
            int counter = 0;
            fs = new Sys.FileSystem.CosmosVFS();

            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            var drives = fs.GetVolumes();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();


            
            
            Console.WriteLine("lists");
            foreach (var drive in drives)
            {
                Console.WriteLine(counter);
                Console.WriteLine("Volume: " + drive.mFullPath);
            }
            
            
            var directory_list = Directory.GetFiles(drivess);
            foreach (var file in directory_list)
            {
                Console.WriteLine(file);
            }
            


        }

        protected override void Run()
        {
            string r = "";
            string[] rr = { };
            string[] rrr = { };
            Console.Write("give me a .csv file name: ");
            var input = Console.ReadLine();
            r = File.ReadAllText(drivess + "\\" + input);
            r = r.Replace("\r","");
            rr = r.Split("\n");
            for (int i = 0; i < rr.Length; i++)
            {
                if (rr[i].Trim() != "") 
                { 

                
                    rrr = rr[i].Split(",");

                
                    for (int j = 0; j < rrr.Length; j++)
                
                    {
                    
                        string sss = rrr[j];
                    
                        sss = sss + "                ";
                    
                        sss = sss.Substring(0, 8);
                    
                        Console.Write(sss+"|");
                
                    }
                
                    Console.WriteLine("");
                }
            }
            
        }
    }
}
