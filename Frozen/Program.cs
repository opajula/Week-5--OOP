using System;
using System.IO;
using System.Text;

namespace XmasConsoleApplication
{
    public class Xmas
    {
        static void Main(string[] args)
        {
            string pathToFile = Path.Combine(Environment.CurrentDirectory, @"frozen.txt");

            using (var fileStream = File.OpenRead(pathToFile))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] inputs = line.Split('/');
                            SecretSanta santa = new SecretSanta(inputs[0], inputs[1]);
                            santa.printWish();
                        }
                }
            }
        }
    }

    class SecretSanta
    {
        string name;
        string gift;

        public SecretSanta(string _name, string _gift)
        {
            this.name = _name;
            this.gift = _gift;
        }

        internal void printWish()
        {
            Console.WriteLine(this.name + " wants " + this.gift);
        }
    }
}
