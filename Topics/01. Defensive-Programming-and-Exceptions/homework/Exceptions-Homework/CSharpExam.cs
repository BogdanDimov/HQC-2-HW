using System;

public class CSharpExam : Exam
{
    public CSharpExam(int score)
    {
        if (score < 0 || score > 100)
        {
            throw new ArgumentOutOfRangeException("Score must be in the range 0 - 100.");
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult CalculateResult()
    {
        var result = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        return result;
    }
}
