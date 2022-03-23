using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int no_of_students = Students.Count;
            if (no_of_students < 5) throw new InvalidOperationException();

            int stundenstPercentage = (int) Math.Round(0.2 * no_of_students);
            List<double> allGrades = new List<double>();

            foreach(Student s in Students)
            {
                allGrades.Add(s.AverageGrade);
            }

            int scoredHigher = allGrades.FindAll(el => el > averageGrade).Count;
            char[] grades = { 'A', 'B', 'C', 'D', 'F' };

            int index = scoredHigher / stundenstPercentage;
            return grades[index];
            
        }
    }
}
