using System.Security.Cryptography.X509Certificates;

namespace readWrite // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static List<string> ReadText(string _fileName)
        {
            List<string> _lines = new List<string>();
            using (StreamReader _sr = new StreamReader(_fileName))
            {
                while (!_sr.EndOfStream)
                {
                    string? _line = _sr.ReadLine();
                    if (_line != null)
                    {
                        _lines.Add(_line);
                    }
                }
            }
            return _lines;
        }

        public static void Menu()
        {
            Console.WriteLine("Select an action\nRead\nWrite\nQuit");
            while (true)
            {
                string? _action = Console.ReadLine();
                if (_action != null)
                {
                    _action.ToLower();
                }
                if (_action == "read")
                {
                    Console.WriteLine("type the name of the file you want to read");
                    List<string> _content = ReadText(AccessFile());
                    Console.WriteLine("this is the content of the file");
                    PrintList(_content);
                }
                else if (_action == "write")
                {
                    Console.WriteLine("type the name of the file you want to write in");
                    WriteText(AccessFile());
                }
                else if (_action == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid action input, read, write or quit");
                }
                Console.WriteLine("select a new action");
            }
            Console.WriteLine("the program is done running");
        }

        public static string AccessFile()
        {
            string _input = Console.ReadLine();
            if (!File.Exists(_input))
            {
                Console.WriteLine("new file created");
                using (FileStream fs = File.Create(_input));
            }
            return _input;
        }

        public static void PrintList(List<string> _lines)
        {
            foreach (string _line in _lines)
            {
                Console.WriteLine(_line);
            }
        }

        public static void WriteText(string _fileName)
        {
            Console.WriteLine("type the text you want to write into the file");
            string[] _lines = Console.ReadLine().Split(@"\n");
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                foreach (string _line in _lines)
                {
                    sw.WriteLine(_line);
                }
            }
        }
    }
}