using System;

namespace MiniProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileType FType = new FileType();
            FType.FindTextFiles();
            
            Console.WriteLine(" ");
            FType.LookUpWord();
        }

    }
}
