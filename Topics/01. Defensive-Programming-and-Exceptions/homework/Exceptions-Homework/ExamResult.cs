using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("Grade must be positive.");
        }

        if (minGrade < 0)
        {
            throw new ArgumentException("Min grade must be positive.");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Max grade must be greater than min grade.");
        }

        if (String.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException();
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
