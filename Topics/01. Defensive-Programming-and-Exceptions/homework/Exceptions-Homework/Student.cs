using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentNullException("Invalid first name!");
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentNullException("Invalid last name!");
        }

        if (exams == null || exams.Count == 0)
        {
            throw new ArgumentNullException("Exams cannot be null or empty!");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IList<Exam> Exams { get; set; }

    public IList<ExamResult> CheckExams()
    {
        var results = new List<ExamResult>();

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].CalculateResult());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        var examResults = CheckExams();
        double[] examScore = new double[this.Exams.Count];

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        var avg = examScore.Average();
        return avg;
    }
}
