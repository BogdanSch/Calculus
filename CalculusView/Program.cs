using Calculus;

public class Program
{
    private static void Main(string[] args)
    {
        EstimateFunction();
        Console.WriteLine("\n");
        ProveSumOfOddNumbersByIduction();
    }

    private static void ProveSumOfOddNumbersByIduction()
    {
        List<string> result = Calculus.Proof.ProveSumOfOddNumbers();
        DisplayList(result);    
    }
    private static void EstimateFunction()
    {
        Func<double, double> func = (x) => Math.Pow(x, 2) + 2 * x + 1;
        string funcDescription = "x^2 + 2*x + 1";
        double x = 3;

        (double result, List<string> explanationSteps) =
            Calculus.Calculus.EvaluateFunctionByValue(func, funcDescription, x);

        Console.WriteLine($"Evaluated result: {result}");
        DisplayList(explanationSteps);
    }

    private static void DisplayList(List<string> explanationSteps)
    {
        for (int i = 0; i < explanationSteps.Count; i++)
        {
            Console.WriteLine(explanationSteps[i]);
        }
    }
}