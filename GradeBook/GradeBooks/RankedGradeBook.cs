using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWighted) :base(name,isWighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count<5)
            {
                throw new InvalidOperationException();
            }
            double min = Double.MaxValue;
            double max = Double.MinValue;
            foreach(var student in Students)
            {
                var av = student.AverageGrade;
                if (min > av) min = av;
                if (max < av) max = av;
            }
            var maxRange = max - min;
            var normalizedAverageGrade = averageGrade - min;


            switch (normalizedAverageGrade/maxRange)
            {
                case var d when d >= 0.80:
                    return 'A';
                    break;
                case var d when d >= 0.6:
                    return 'B';
                    break;
                case var d when d >= 0.4:
                    return 'C';
                    break;
                case var d when d >= 0.2:
                    return 'D';
                    break;
            }


            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);

        }
    }
}
