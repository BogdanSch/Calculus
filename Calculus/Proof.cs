namespace Calculus;
public static class Proof
{
    public static List<string> DirectProof(int number, int denominator = 2)
    {
        List<string> result = new List<string>();

        result.Add($"Given number: {number}");

        double rest = number % denominator;

        result.Add($"Step 1: Let's divide {number} by {denominator} = {number / denominator}.");
        if (rest == 0)
        {
            result.Add($"Step 2: The number {number} is divisible by {denominator}.");
        }
        else
        {
            result.Add($"Step 2: The number {number} isn't divisible by {denominator}.");
        }

        return result;
    }
    //public static List<string> ProofByInduction(Func<int, int> calculateSumOfOddNumbers, int k)
    //{
    //    if (k < 1) throw new Exception("Error: number should be greater or equal to one!");

    //    List<string> result = new List<string>();
    //    result.Add("Proof by Induction");

    //    result.Add("Step 1: Base Case (n = 1): The relation for 1 has to be held 1^2 = 1");
    //    if(calculateSumOfOddNumbers(1) == Math.Pow(1, 2))
    //    {
    //        result.Add("Base case verified for n = 1.");
    //    }
    //    else
    //    {
    //        result.Add("Base case failed for n = 1. Proof invalid!");
    //        return result;
    //    }

    //    result.Add("Step 2: Induction Hypothesis");
    //    result.Add($"Let's assume that the sum of k odd numbers = k^2 = {k}^2={k*k}");

    //    double expectedSum = Math.Round(Math.Pow(k + 1, 2));
    //    double actualSum = Math.Pow(k, 2) + (2 * k + 1);

    //    result.Add($"Inductive step: The sum of the first k + 1 odd numbers equals k^2 + (2k + 1) = (k + 1)^2 = ({k+1})^2 = {expectedSum}");
    //    if (expectedSum == actualSum) 
    //    {
    //        result.Add("Induction step verified!");
    //    }
    //    else
    //    {
    //        result.Add("Induction step failed. Proof invalid!");
    //        return result;
    //    }

    //    result.Add("Conclusion: The statement is proven by induction.");
    //    return result;
    //}
    public static List<string> ProveByInduction(Func<int, bool> statement, Func<int, string> baseCase, Func<int, string> inductionStep)
    {
        List<string> proofSteps = new List<string>();

        // Base Case Verification
        string baseCaseResult = baseCase(1);
        proofSteps.Add($"Base Case: {baseCaseResult}");

        // If base case fails, stop the proof
        if (!statement(1))
        {
            proofSteps.Add("Base Case failed: The statement does not hold for n = 1.");
            return proofSteps;
        }

        proofSteps.Add("Induction Hypothesis: Assume the statement holds for n = k.");

        for (int k = 2; k <= 4; k++)
        {
            string stepResult = inductionStep(k);
            proofSteps.Add($"\tInduction Step for k = {k}: {stepResult}");

            if (!statement(k + 1))
            {
                proofSteps.Add($"Induction failed at k = {k}: The statement does not hold for n = {k + 1}.");
                break;
            }
        }

        return proofSteps;
    }

    //public static List<string> ProveSumOfOddNumbers()
    //{
    //    Func<int, int> calculateSumOfOddNumbers = (int n) =>
    //    {
    //        int sum = 1;
    //        for (int i = 3, count = 1; count < n; i += 2, count++)
    //        {
    //            sum += i;
    //        }
    //        return sum;
    //    };
    //    Func<int, double> squarePower = (int n) => Math.Pow(n, 2);
    //    //const int checkNumber = 4;
    //    Func<int, bool> statement = n => calculateSumOfOddNumbers(n) == squarePower(n);
    //    Func<int, bool> baseCase = n => calculateSumOfOddNumbers(1) == squarePower(1);
    //    Func<int, bool> inductionStep = k => calculateSumOfOddNumbers(k + 1) == squarePower(k + 1);

    //    return ProveByInduction(statement, baseCase, inductionStep);
    //    //return ProveByInduction(calculateSumOfOddNumbers, checkNumber);
    //}
    public static List<string> ProveSumOfOddNumbers()
    {
        Func<int, int> calculateSumOfOddNumbers = (int n) =>
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += 2 * i + 1;
            }
            return sum;
        };

        Func<int, double> squarePower = (int n) => Math.Pow(n, 2);

        Func<int, bool> statement = n => calculateSumOfOddNumbers(n) == squarePower(n);

        Func<int, string> baseCase = (int n) =>
        {
            int sum = calculateSumOfOddNumbers(1);
            double square = squarePower(1);
            return $"Verify for n = 1: SumK(1) = {sum}, 1^2 = {square}. {(sum == square ? "Holds" : "Does not hold")}";
        };

        Func<int, string> inductionStep = (int k) =>
        {
            int sumK = calculateSumOfOddNumbers(k);
            int nextOdd = 2 * k + 1;
            int sumKPlus1 = sumK + nextOdd;
            double squareKPlus1 = squarePower(k + 1);
            return $"Assume true for n = k: SumK(k) = {sumK}.\nAdd next odd number {nextOdd}: Sum(k+1) = {sumKPlus1}. Verify: {sumKPlus1} == {squareKPlus1}. {(sumKPlus1 == squareKPlus1 ? "Holds" : "Does not hold")}";
        };

        return ProveByInduction(statement, baseCase, inductionStep);
    }
}
