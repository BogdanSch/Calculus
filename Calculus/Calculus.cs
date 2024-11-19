using System.Text;
using System.Text.RegularExpressions;

namespace Calculus;

public static class Calculus
{
    public static string DetermineParity(int number)
    {
        return number % 2 == 0 ? "Even" : "Odd";
    }
    public static string DeterminePrime(int number)
    {
        bool isPrime = true;

        for (int i = 2; i < Math.Abs(number); i++)
        {
            if (number % i == 0) isPrime = false;
        }

        return isPrime ? "Prime" : "Not Prime";
    }
    public static int DetermineGCD(int number1, int number2)
    {
        if (number1 == 0)
            return number2;
        return DetermineGCD(number2 % number1, number1);
    }
    public static int DetermineLCM(int number1, int number2)
    {
        return (number1 / DetermineGCD(number1, number2)) * number2;
    }
    public static string DeterminePrimeFactors(int n)
    {
        if (n <= 1) return n.ToString();

        StringBuilder result = new StringBuilder();
        int countOfTwo = 0;
        while (n % 2 == 0)
        {
            countOfTwo++;
            n /= 2;
        }

        if (countOfTwo > 1) result.Append($"2^{countOfTwo} * ");
        else if (countOfTwo == 1) result.Append($"2 * ");

        for (int i = 3; i <= Math.Sqrt(n); i += 2)
        {
            int countOfTemporary = 0;
            while (n % i == 0)
            {
                countOfTemporary++;
                n /= i;
            }
            if (countOfTemporary > 1)
                result.Append($"{i}^{countOfTemporary} * ");
            else if (countOfTemporary == 1) result.Append($"{i} * ");
        }

        if (n > 2)
            result.Append(n);
        if (result.Length > 2 && result.ToString().EndsWith(" * "))
            result.Length -= 3;

        return result.ToString();
    }
    public static int EvaluateEulerTotient(int number)
    {
        int result = 1;
        
        for (int i = 2; i < number; i++)
        {
            if(DetermineGCD(i, number) == 1)
            {
                result++;
            }
        }

        return result;
    }
    public static bool IsWithinDomain(Func<double, double> func, double value)
    {
        try
        {
            double result = func(value);
            if(double.IsNaN(result)) return false;
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
    private static List<string> GenerateFunctionCalculationSteps(string funcDescription, double x)
    {
        // Remove spaces and handle Cyrillic characters and case
        string substitutedFunc = funcDescription.Replace(" ", "");
        substitutedFunc = substitutedFunc.Replace("х", "x").ToLower();

        // Handle negative signs by replacing them with '+-' for easier parsing
        substitutedFunc = substitutedFunc.Replace("-", "+-");

        // Substitute x with the given value
        substitutedFunc = substitutedFunc.Replace("x", x.ToString());

        // Split the function into terms based on '+' sign
        string[] terms = substitutedFunc.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

        double result = 0;
        bool isSubtraction = false; // Flag to handle subtraction
        List<string> steps = new List<string>
    {
        $"Substitute x = {x}: {substitutedFunc.Replace("+-", "-")}"
    };

        foreach (string term in terms)
        {
            string cleanTerm = term.Trim();

            double parsedTerm;

            // Handle terms with exponentiation (e.g., x^2)
            if (cleanTerm.Contains("^"))
            {
                string[] parts = cleanTerm.Split('^');
                double baseValue = double.Parse(parts[0]);
                double exponent = double.Parse(parts[1]);
                double powerResult = Math.Pow(baseValue, exponent);

                result += isSubtraction ? -powerResult : powerResult;
                steps.Add($"Calculate {baseValue}^{exponent} = {powerResult}");
            }
            // Handle terms with multiplication (e.g., 3*x or 2*5)
            else if (cleanTerm.Contains("*"))
            {
                string[] parts = cleanTerm.Split('*');
                double left = double.Parse(parts[0]);
                double right = double.Parse(parts[1]);
                double product = left * right;

                result += isSubtraction ? -product : product;
                steps.Add($"Calculate {left}*{right} = {product}");
            }
            // Handle constant terms (e.g., numbers without variables)
            else if (double.TryParse(cleanTerm, out parsedTerm))
            {
                result += isSubtraction ? -parsedTerm : parsedTerm;
                steps.Add($"{(isSubtraction ? "Subtract" : "Add")} constant {parsedTerm}");
            }

            if (cleanTerm.StartsWith("-"))
            {
                isSubtraction = true;
            }
            else
            {
                isSubtraction = false;
            }
        }

        steps.Add($"Final result: {result}");
        return steps;
    }
    public static (double, List<string>) EvaluateFunctionByValue(Func<double, double> func, string funcDescription, double value)
    {
        List<string> explanationSteps = new List<string>();
        if (!IsWithinDomain(func, value)) throw new Exception("Exception: Out of domain value");

        explanationSteps.Add($"The value {value} is within the functions domain.");
        explanationSteps.Add($"Evaluating function f(x) = {funcDescription}");
        explanationSteps.AddRange(GenerateFunctionCalculationSteps(funcDescription, value));

        return (func(value), explanationSteps); 
    }
}
