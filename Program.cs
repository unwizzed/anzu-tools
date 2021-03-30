using Console = Colorful.Console;
using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Leaf.xNet;
using System.Collections.Specialized;
using Microsoft.Win32;

namespace Anzu_Tools
{
    class Program
    {
        static int key;
      
        static void SetBanner()
        {
            Console.Title = "Anzu Combo Tools [v1.0] - Made By Loric";
            Console.WriteLine("\n");
            Console.WriteLine("                                        ▄▄▄       ███▄    █ ▒███████▒ █    ██   ", Color.FromArgb(226, 41, 70));
            Console.WriteLine("                                       ▒████▄     ██ ▀█   █ ▒ ▒ ▒ ▄▀░ ██  ▓██▒  ", Color.FromArgb(226, 41, 80));
            Console.WriteLine("                                       ▒██  ▀█▄  ▓██  ▀█ ██▒░ ▒ ▄▀▒░ ▓██  ▒██░  ", Color.FromArgb(226, 41, 100));
            Console.WriteLine("                                       ░██▄▄▄▄██ ▓██▒  ▐▌██▒  ▄▀▒   ░▓▓█  ░██░  ", Color.FromArgb(226, 41, 120));
            Console.WriteLine("                                        ▓█   ▓██▒▒██░   ▓██░▒███████▒▒▒█████▓   ", Color.FromArgb(226, 41, 140));
            Console.WriteLine("                                        ▒▒   ▓▒█░░ ▒░   ▒ ▒ ░▒▒ ▓░▒░▒░▒▓▒ ▒ ▒   ", Color.FromArgb(226, 41, 160));
            Console.WriteLine("                                        ▒   ▒▒ ░░ ░░   ░ ▒░░░▒ ▒ ░ ▒░░▒░ ░ ░    ", Color.FromArgb(226, 41, 180));
            Console.WriteLine("                                        ░   ▒      ░   ░ ░ ░ ░ ░ ░ ░ ░░░ ░ ░    ", Color.FromArgb(226, 41, 200));
            Console.WriteLine("                                        ░  ░         ░   ░ ░       ░            ", Color.FromArgb(226, 41, 220));
            Console.Write("\n                                                  A", Color.FromArgb(226, 41, 70));
            Console.Write("n", Color.FromArgb(226, 41, 80));
            Console.Write("z", Color.FromArgb(226, 41, 100));
            Console.Write("u", Color.FromArgb(226, 41, 120));
            Console.Write(" C", Color.FromArgb(226, 41, 140));
            Console.Write("o", Color.FromArgb(226, 41, 160));
            Console.Write("m", Color.FromArgb(226, 41, 180));
            Console.Write("b", Color.FromArgb(226, 41, 200));
            Console.Write("o", Color.FromArgb(226, 41, 220));
            Console.Write(" T", Color.FromArgb(226, 41, 240));
            Console.Write("o", Color.FromArgb(200, 41, 240));
            Console.Write("o", Color.FromArgb(180, 41, 240));
            Console.Write("l", Color.FromArgb(160, 41, 240));
            Console.Write("s\n\n\n", Color.FromArgb(140, 41, 240));

        }
        [STAThread]
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
        Main:
            Random rnd = new Random();
            SetBanner();
            Console.Write("[", Color.White); Console.Write("1", Color.FromArgb(226, 41, 80)); Console.Write("] Domain Sorter\n", Color.White);
            Console.Write("[", Color.White); Console.Write("2", Color.FromArgb(226, 41, 100)); Console.Write("] Combo Shuffler\n", Color.White);
            Console.Write("[", Color.White); Console.Write("3", Color.FromArgb(226, 41, 120)); Console.Write("] Combo Merger\n", Color.White);
            Console.Write("[", Color.White); Console.Write("4", Color.FromArgb(226, 41, 140)); Console.Write("] Combo Splitter\n", Color.White);
            Console.Write("[", Color.White); Console.Write("5", Color.FromArgb(226, 41, 160)); Console.Write("] Exit Program\n", Color.White);
            Console.Write("\n>", Color.White);
            Console.ResetColor();
            Console.ForegroundColor = Color.White;


            try
            {
                key = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                goto Main;
            }
            Console.Clear();
            if (key == 1)
            {
                SetBanner();
                Console.Write("[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 80)); Console.Write("] Enter domain (ex : @hotmail): ", Color.White);
                string domain = Console.ReadLine();
            pickcombo:
                Console.Write("[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Press any button to load your combo...", Color.White);
                Console.ReadKey();
                OpenFileDialog fd = new OpenFileDialog();
                fd.Title = "Choose Your Combo";
                fd.Filter = "Text files(*.txt)| *.txt";
                DialogResult result = fd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    stopwatch.Start();

                    string[] lines = File.ReadAllLines(fd.FileName);
                    List<string> filtered = new List<string>();

                    foreach (string line in lines)
                    {
                        if (line.Contains(domain))
                        {
                            filtered.Add(line);
                        }
                        else
                        {

                        }
                    }
                    stopwatch.Stop();
                    File.WriteAllLines(AppContext.BaseDirectory + domain + "_" + rnd.Next(0, 400000) + ".txt", filtered);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Found ["); Console.Write(filtered.Count, Color.FromArgb(226, 41, 140)); Console.Write("] lines!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Finished, took " + stopwatch.Elapsed.TotalMilliseconds + " ms!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Press any button to go back to the main menu...", Color.White);
                    Console.Read();
                    Console.Read();
                    Console.Clear();
                    goto Main;
                }
                else
                {
                    goto pickcombo;
                }

            }
            else if (key == 2)
            {
                SetBanner();
            pickcombo:
                Console.Write("[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Press any button to load your combo...", Color.White);
                Console.ReadKey();
                OpenFileDialog fd = new OpenFileDialog();
                fd.Title = "Choose Your Combo";
                fd.Filter = "Text files(*.txt)| *.txt";
                DialogResult result = fd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    stopwatch.Start();

                    List<string> lines = new List<string>(File.ReadAllLines(fd.FileName));

                    var shuffled = lines.OrderBy(x => Guid.NewGuid()).ToList();

                    stopwatch.Stop();
                    File.WriteAllLines(AppContext.BaseDirectory + "mixed_combo" + "_" + rnd.Next(0, 400000) + ".txt", shuffled);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Shuffled ["); Console.Write(shuffled.Count, Color.FromArgb(226, 41, 140)); Console.Write("] lines!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Finished, took " + stopwatch.Elapsed.TotalMilliseconds + " ms!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Press any button to go back to the main menu...", Color.White);
                    Console.Read();
                    Console.Read();
                    Console.Clear();
                    goto Main;
                }
                else
                {
                    goto pickcombo;
                }
            }
            else if (key == 3)
            {
                SetBanner();
            pickcombo:
                Console.Write("[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Press any button to load your combo...", Color.White);
                Console.ReadKey();
                OpenFileDialog fd = new OpenFileDialog();
                fd.Multiselect = true;
                fd.Title = "Choose Your Combos";
                fd.Filter = "Text files(*.txt)| *.txt";
                DialogResult result = fd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    stopwatch.Start();

                    List<string> newcombo = new List<string>();

                    foreach (string FileName in fd.FileNames)
                    {
                        List<string> lines = new List<string>(File.ReadAllLines(FileName));
                        foreach (string line in lines)
                        {
                            newcombo.Add(line);
                        }
                    }


                    stopwatch.Stop();
                    File.WriteAllLines(AppContext.BaseDirectory + "merged_combo" + "_" + rnd.Next(0, 400000) + ".txt", newcombo);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Merged ["); Console.Write(newcombo.Count, Color.FromArgb(226, 41, 140)); Console.Write("] lines!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Finished, took " + stopwatch.Elapsed.TotalMilliseconds + " ms!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Press any button to go back to the main menu...", Color.White);
                    Console.Read();
                    Console.Read();
                    Console.Clear();
                    goto Main;
                }
                else
                {
                    goto pickcombo;
                }
            }
            else if (key == 4)
            {
                SetBanner();
                pickcombo:
                    Console.Write("[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] How many lines per text file do you want: ", Color.White);
                    int lineCount = Int32.Parse(Console.ReadLine());
                    Console.Write("[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Press any button to load your combo...", Color.White);
                    Console.ReadKey();
                    OpenFileDialog fd = new OpenFileDialog();
                    fd.Title = "Choose Your Combo";
                    fd.Filter = "Text files(*.txt)| *.txt";
                    DialogResult result = fd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    stopwatch.Start();
                    List<string> lines = new List<string>(File.ReadAllLines(fd.FileName));
                    Directory.CreateDirectory(AppContext.BaseDirectory + $"{fd.SafeFileName}_splitted");
                    string dir = $"{fd.SafeFileName}_splitted";
                    int i = 0;
                    int g = 1;
                    List<string> split = new List<string>();
                    foreach (string line in lines)
                    {
                        if (i < lineCount)
                        {
                            split.Add(line);
                            i += 1;
                        }
                        else
                        {
                            File.WriteAllLines(AppContext.BaseDirectory + dir + "/" + "splitted_"+g+".txt", split);
                            split = new List<string>();
                            g += 1;
                            i = 0;
                            split.Add(line);
                            i += 1;
                        }
                        
                    }


                    stopwatch.Stop();
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Splitted ["); Console.Write(lines.Count, Color.FromArgb(226, 41, 140)); Console.Write("] lines!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Finished, took " + stopwatch.Elapsed.TotalMilliseconds + " ms!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Created ["); Console.Write(g, Color.FromArgb(226, 41, 140)); Console.Write("] files!", Color.White);
                    Console.Write("\n[", Color.White); Console.Write(">", Color.FromArgb(226, 41, 100)); Console.Write("] Press any button to go back to the main menu...", Color.White);
                    Console.Read();
                    Console.Read();
                    Console.Clear();
                    goto Main;
                }
                else if (key == 5)
                {
                    return;
                }
                else
                {
                    goto Main;
                }
            }
        }
    }
}
