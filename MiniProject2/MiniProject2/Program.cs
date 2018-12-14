using System;

namespace MiniProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileType FType = new FileType();
            FType.FindTextFiles();
            FType.WordDump();
            FType.PrintDictionary();
            

           
        }
    }
}
