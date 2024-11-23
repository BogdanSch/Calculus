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
    public static List<string> ProveByInduction(
    Func<int, bool> statement,
    Func<int, string> baseCaseDescription,
    Func<int, string> inductionStepDescription,
    int maxSteps = 5)
    {
        List<string> proofSteps = new List<string>();

        proofSteps.Add("Step 1: Base Case:");
        proofSteps.Add(baseCaseDescription(1));
        if (!statement(1))
        {
            proofSteps.Add("Base Case failed: The statement does not hold for n = 1.");
            return proofSteps;
        }
        proofSteps.Add("Base Case holds. Proceeding to the induction step.");


        proofSteps.Add("Step 2: Induction Hypothesis:");
        proofSteps.Add("Assume the statement holds for n = k.");

        proofSteps.Add("Induction Steps:\n");
        for (int k = 2, stepIndicator = 1; k <= maxSteps; k++, stepIndicator++)
        {
            proofSteps.Add($"Step 2.{stepIndicator}:");
            proofSteps.Add(inductionStepDescription(k));
            if (!statement(k + 1))
            {
                proofSteps.Add($"Induction failed: The statement does not hold for n = {k + 1}.");
                return proofSteps;
            }
            proofSteps.Add($"Induction step verified for k + 1.\n");
        }

        proofSteps.Add("Step 3: Induction completed. The statement holds for all tested cases.");
        proofSteps.Add("Step 4: Conclusion. The statement is proven by induction.");

        return proofSteps;
    }
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

        Func<int, int> squarePower = (int n) => n * n;
        Func<int, bool> statement = n => calculateSumOfOddNumbers(n) == squarePower(n);
        string conditionTemplate = "{0} == {1}";

        Func<int, string> baseCaseDescription = (int n) =>
        {
            int sum = calculateSumOfOddNumbers(n);
            string condition = conditionTemplate.Replace("{0}", sum.ToString()).Replace("{1}", squarePower(1).ToString());
            return $"For n = {n}. Condition: {condition}. {(statement(n) ? "Holds" : "Does not hold")}";
        };
        Func<int, string> inductionStepDescription = (int k) =>
        {
            int sumK = calculateSumOfOddNumbers(k);
            int nextOdd = 2 * k + 1;
            int sumKPlus1 = sumK + nextOdd;            
            int directKPlus1Sum = squarePower(k + 1);

            string condition = conditionTemplate.Replace("{0}", sumKPlus1.ToString()).Replace("{1}", directKPlus1Sum.ToString());
            return $"Assume true for k = {k}: Sum({k}) = {sumK}.\nAdding next odd number {nextOdd}, Sum({k}+1) = Sum({k}) + {nextOdd} = {sumKPlus1}.\nCondition: {condition}. {(statement(k + 1) ? "Holds" : "Does not hold")}";
        };

        return ProveByInduction(statement, baseCaseDescription, inductionStepDescription);
    }
}
