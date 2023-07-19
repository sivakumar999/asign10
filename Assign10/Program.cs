using System;
using System.IO;

namespace FileHandlingEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
               

                Console.WriteLine("Choose an operation \n1.Create file \n2.Append Contnet \n3.Read content \n4.Delete file:");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice >= 1 && choice <= 4)
                {

                    Console.WriteLine("Enter the file path:");
                    string path = Console.ReadLine();


                    string fName;
                    string fPath;

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the filename:");
                            fName = Console.ReadLine();
                            fPath = Path.Combine(path, fName);

                            if (File.Exists(fPath))
                            {
                                Console.WriteLine("The file already exists!!!");
                            }
                            else
                            {
                                File.Create(fPath);
                                Console.WriteLine("File is Created");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Enter the file name:");
                            string fName2 = Console.ReadLine();
                            string fPath2 = Path.Combine(path, fName2);

                            if (File.Exists(fPath2))
                            {
                                Console.WriteLine("File Already exists");
                            }
                            else
                            {
                                using (StreamWriter sw = File.AppendText(fPath2))
                                {
                                    sw.WriteLine("Welcome to Stream Writing");
                                    sw.WriteLine("Welcome to my example");
                                }

                                Console.WriteLine("Created and text is written");
                            }
                            break;

                        case 3:
                            Console.WriteLine("Enter the file name:");
                            string fName3 = Console.ReadLine();
                            string fpath3 = Path.Combine(path, fName3);
                            StreamReader sr = null;
                            try
                            {
                                sr = new StreamReader(fpath3);
                                string text = "";
                                while ((text = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(text);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!" + ex.Message);
                            }
                            finally
                            {
                                if (sr != null)
                                    sr.Close();
                            }
                            break;



                        case 4:
                            Console.WriteLine("Enter File Name to Delete");
                            fName = Console.ReadLine();
                            fPath = Path.Combine(path, fName);
                            if (File.Exists(fPath))
                            {
                                File.Delete(fPath);
                                Console.WriteLine("File Deleted Permanently!!!");
                            }
                            else { Console.WriteLine("File does not exist"); }
                            break;

                        default:

                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("invalid Choice.Please enter your choice 1 to 4");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
