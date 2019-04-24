using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace MiniProject
{
    public class FileType
    {
        public FileType()
        {
            directories = new List<string>();
            file_name = new List<string>();
        }

        // Iteratively get the path of txt files from tree that starts at "StartingFolder", get the name of the txt files.  
        // Store the value of both path and file names in list directories and list file_name, respectively.
        // Print out the path with corresponding numbers for future file selection.
        public void FindTextFiles()
        {
            try
            {
                string[] dirs = Directory.GetFiles(@"..\..\..\..\StartingFolder", "*.txt", SearchOption.AllDirectories);
                int number = 0;
                foreach (string dir in dirs)
                {
                    number += 1;
                    directories.Add(dir.Substring(12));
                    Console.WriteLine(number + "   " + dir.Substring(12));
                    var file = Path.GetFileName(dir);
                    file_name.Add(file);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("You Suck!  Check your path.");
            }
        }
        public List<string> directories;
        public List<string> file_name;


        // Allows user input to select file by corresponding numbers.  Ensures that the number selected is within range.
        // Store and print the number of the file chosen by user.  Assumes user enters a number and not a letter/symbol.
        public int ChooseFileNumber()
        {
            Console.WriteLine("Please select file number. ");
            int input = Int32.Parse(Console.ReadLine());
            var lengthDir = directories.Count;

            while (input < 0 || input == 0 || input > lengthDir)
            {
                Console.WriteLine("This number is out of range. ");
                Console.WriteLine("Please select file number. ");
                int input1 = Int32.Parse(Console.ReadLine());

                if (input1 > 0 && input1 <= lengthDir)
                {
                    input = input1;
                    break;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("You selected file {0}.", input);
            return input;
        }


        // Based on the previously stored numbre from ChooseFileNumber, store and print out the file name.
        public string GetTextFileName()
        {
            int indexed = ChooseFileNumber();
            string FileName = file_name[indexed - 1];
            Console.WriteLine(FileName);
            Console.WriteLine(" ");
            return FileName;
        }


        // Extract the content of the file in string format.  Store and print out the chosen string.
        public string TextString()
        {
            try
            {
                string FName = GetTextFileName();
                string[] document = Directory.GetFiles(@"..\..\..\..\StartingFolder", FName, SearchOption.AllDirectories);
                var document1 = string.Join("", document);
                string text = File.ReadAllText(document1);
                Console.WriteLine("Text from selected file: ");
                return text;
            }
            catch (Exception)
            {
                Console.WriteLine("Nee!  Check your path.");
                return "NOPE.";
            }
        }


        // Removes punctuation, and separates the string into an array of strings.
        public string[] StringStrip()
        {
            string FileString = TextString();

            Console.WriteLine(FileString);
            string words = Regex.Replace(FileString, @"[.,!;?]", "");
            var words_noPunctuation = words.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return words_noPunctuation;
        }


        // Strip the array of punctuation and place into a dictionary.  Dictionary key is the string and the value is the indexed location.
        public Dictionary<string, List<int>> MungeString()
        {
            string[] words_noPunctuation = StringStrip();
            Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();

            for (int i = 0; i < words_noPunctuation.Length; i++)
            {
                string key = words_noPunctuation[i].ToLower();
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(i);
                }
                else
                {
                    List<int> value = new List<int>();
                    value.Add(i);
                    dictionary.Add(key, value);
                }
            }
            return dictionary;
        }



        // Allows user input to select a word from the string from file by corresponding numbers.  Ensures that the number selected is within range.
        // Store and print the number of the word chosen by user and its indexed locations.  Assumes user enters a number and not a letter/symbol.
        public void LookUpWord()
        {
            Dictionary<string, List<int>> fDict = MungeString();
            var arrayOfKeys = fDict.Keys.ToArray();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Please select a number. ");

            int counter = 0;
            foreach (string key in arrayOfKeys)
            {
                counter += 1;
                Console.WriteLine("{0}   {1}", counter, key);
            }

            int inputForWord = Int32.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine("You selected number {0}", inputForWord);

            while (inputForWord < 0 || inputForWord == 0 || inputForWord > (arrayOfKeys.Length))
            {
                Console.WriteLine("This number is out of range. ");
                Console.WriteLine("Please select file number. ");
                int inputForWord1 = Int32.Parse(Console.ReadLine());

                if (inputForWord1 > 0 && inputForWord1 <= arrayOfKeys.Length)
                {
                    inputForWord = inputForWord1;
                    break;
                }
            }

            string wordLookUp = arrayOfKeys[inputForWord - 1];
            Console.WriteLine("That corresponds to {0}.", wordLookUp);
            if (fDict.ContainsKey(wordLookUp))
            {
                List<int> poptarts = fDict[wordLookUp];
                var result = string.Join(",", poptarts);
                Console.WriteLine(" ");
                Console.WriteLine("{0} is found at index {1}.", wordLookUp, result);
                Console.ReadLine();
            }
        }
    }
}

