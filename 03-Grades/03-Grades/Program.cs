﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();
            Console.WriteLine("Foobar");
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }
        
        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }
            WriteResult("Average Grade", stats.AverageGrade);
            WriteResult("Highest Grade", stats.HighestGrade);
            WriteResult("Lowest Grade", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputfile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputfile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name.");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + ": " + result);
        }
    }
}
