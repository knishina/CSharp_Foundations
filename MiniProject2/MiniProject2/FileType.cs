using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniProject2
{
    public class FileType
    {
        public FileType()
        {
            file_name = new List<string>();
        }


        // Starts at a given directory and dumps the complete paths of all txt files 
        // into a list. 
        public void FindTextFiles()
        {
            try
            {
                string[] dirs = Directory.GetFiles(@"..\..\..\..\StartingFolder", "*.txt", SearchOption.AllDirectories);
                foreach (string dir in dirs)
                {
                    var file = Path.GetFullPath(dir);
                    file_name.Add(file);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("You Suck!  Check your path.");
            }
        }
        public List<string> file_name;


        // Takes the complete path, grabs string of text within the txt file.
        // Removes punctuation, changes to all lowercase, and splits on spaces.
        // If the word is greater than length 1, it checks if it is in the dictionary.
        // If in dictionary, it increments the value.  Else, it adds the key to the dictionary.
        public Dictionary<string, int> dictionary = new Dictionary<string, int>();
        public void WordDump()
        {
            foreach (string file in file_name)
            {
                string text = File.ReadAllText(file);
                string textNoPuncts = Regex.Replace(text, @"[.,!;?]", "").ToLower();
                var word_split = textNoPuncts.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in word_split)
                {
                    if (word.Length > 1) { 
                        if (!dictionary.ContainsKey(word))
                        {
                            dictionary.Add(word, 1);
                        }
                        else
                        {
                            dictionary[word]++;
                        }
                    }
                }
            }
        }


        // Print out the dictionary.
        public void PrintDictionary()
        {
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);

            }
        }
    }

}
