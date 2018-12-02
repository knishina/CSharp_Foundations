using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Grades
{
    public class ThrowAwayGradeBook: GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Not FUBAR!");
            float lowest = float.MaxValue;
            foreach(float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
