using System;
using System.IO;
using System.IO.Enumeration;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace readWrite // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      menu();
    }
    public static List<string> Readtext(string fileName)
    {
      List<string> lines = new List<string>();
      using (StreamReader sr = new StreamReader(fileName))
      {

        while (!sr.EndOfStream)
          {
            lines.Add(sr.ReadLine());
          }
      }
      return lines;
    }
    public static void menu()
    {
      Console.WriteLine("Select an action\n1 for Read\n2 for Write\n3 to quit");
      while (true)
      {
        string action = Console.ReadLine();
        if (action == "1")
        {
          Console.WriteLine("type the name of the file you want to read");
          List<string> content = Readtext(accessFile());
          Console.WriteLine("this is the content of the file");
          printList(content);
        }
        else if(action == "2")
        {
          Console.WriteLine("type the name of the file you want to write in");
          Writetext(accessFile());

        }
        else if(action == "3")
        {
          break;
        }
        else 
        {
          Console.WriteLine("invalid action select 1, 2, or 3"); 
        }
        Console.WriteLine("select a new action");
      }
      Console.WriteLine("the program is done running");


    }
    public static string accessFile()
    {
      string input = Console.ReadLine();
      if (!File.Exists(input))
      {
        Console.WriteLine("new file created");
        FileStream fs = File.Create(input);
        fs.Close();
      }

      return input;
    }
    public static void printList(List<string> lines)
    {
      foreach (string line in lines)
      {
        Console.WriteLine(line);
      }
    }

    public static void Writetext(string fileName) 
    {
      Console.WriteLine("type the text you want to write into the file");
      string[] lines = Console.ReadLine().Split(@"\n");

      using (StreamWriter sw = new StreamWriter(fileName)) 
      {
        foreach(string line in lines)
        {
          sw.WriteLine(line);
        }
      }
    }
  }
}