public class SimpleMathExam : Exam
{
    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            problemsSolved = 0;
        }

        if (problemsSolved > 10)
        {
            problemsSolved = 10;
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult CalculateResult()
    {
        if (ProblemsSolved >= 0 || ProblemsSolved <= 3)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved >= 4 || ProblemsSolved <= 6)
        {
            return new ExamResult(4, 2, 6, "Average result: only part of the problems are done.");
        }
        else if (ProblemsSolved >= 7)
        {
            return new ExamResult(6, 2, 6, "Excellent result: all or almost all problems done.");
        }

        var examResult = new ExamResult(0, 0, 0, "Invalid number of problems solved!");
        return examResult;
    }
}
