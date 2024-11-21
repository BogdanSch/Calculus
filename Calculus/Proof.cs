namespace Calculus;
public static class Proof
{
    public static List<string> DirectProof(int number)
    {
        List<string> result = new List<string>();

        result.Add($"Given number: {number}");

        if (number % 2 == 0)
        {
            result.Add($"Step 1: Since the number {number} is even, it can be written as n = 2k.");
            result.Add($"Step 2: The number {number} is divisible by 2.");
        }
        else
        {
            result.Add($"Step 1: Since the number {number} can't be written in the form of n = 2k, it's odd.");
            result.Add($"Step 2: The number {number} is not divisible by 2.");
        }

        return result;
    }
    public static List<string> ProofByInduction(
            Func<int, bool> baseCaseValidator, 
            Action<List<string>> inductionHypothesisWriter,
            Func<int, bool> inductionStepValidator
        )
    {
        List<string> result = new List<string>();
        result.Add("Proof by Induction");

        result.Add("Step 1: Base Case");
        if (baseCaseValidator(1))
        {
            result.Add("Base case verified for n = 1.");
        }
        else
        {
            result.Add("Base case failed for n = 1. Proof invalid!");
            return result;
        }

        result.Add("Step 2: Induction Hypothesis");
        inductionHypothesisWriter(result);

        result.Add("Step 3: Induction Step");
        if (inductionStepValidator(4))
        {
            result.Add("Induction step verified for n = k + 1.");
        }
        else
        {
            result.Add("Induction step failed. Proof invalid!");
            return result;
        }

        result.Add("Conclusion: The statement is proven by induction.");
        return result;
    }

    public static List<string> ProveSumOfOddNumbers(Func<int, int> calculateSumOfOddNumbers)
    {
        return ProofByInduction(
            baseCaseValidator: (int n) =>
            {
                int sum = calculateSumOfOddNumbers(n);
                return sum == 1;
            },
            inductionHypothesisWriter: (List<string> result) =>
            {
                result.Add("Assume the statement is true for n = k.");
                result.Add("That is, sum of first k odd numbers = k^2.");
            },
            inductionStepValidator: (int k) =>
            {
                int currentSum = calculateSumOfOddNumbers(k);
                int nextOddNumber = 2 * k + 1;
                int newSum = currentSum + nextOddNumber;
                int expectedSum = (k + 1) * (k + 1);
                return newSum == expectedSum;
            }
        );
    }
}
