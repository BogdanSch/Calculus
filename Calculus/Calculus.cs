using System.Text;

namespace Calculus;

public static class Calculus
{
    public static string DetermineParity(int number)
    {
        return number % 2 == 0 ? "Even" : "Odd";
    }
    public static string DeterminePrime(int number)
    {
        for (int i = 2; i < Math.Abs(number); i++)
        {
            if (number % i == 0) return "Not Prime";
        }

        return "Prime";
    }
    public static int DetermineGCD(int number1, int number2)
    {
        if (number1 == 0)
            return number2;
        return DetermineGCD(number2 % number1, number1);
    }
    public static int DetermineLCM(int number1, int number2)
    {
        return Math.Abs(number1 * number2) / DetermineGCD(number1, number2);
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
        if (result.Length > 3 && result.ToString().EndsWith(" * "))
            result.Length -= 3;

        return result.ToString();
    }
    public static int EvaluateEulerTotient(int number)
    {
        int result = 1;
        
        for (int i = 2; i < number; i++)
        {
            if(DetermineGCD(i, number) == 1) //Common factor is one
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
        string substitutedFunc = funcDescription.Replace(" ", "");
        substitutedFunc = substitutedFunc.Replace("-", "+-");

        substitutedFunc = substitutedFunc.Replace("x", x.ToString());

        string[] terms = substitutedFunc.Split('+', StringSplitOptions.RemoveEmptyEntries);

        double result = 0;
        List<string> steps = new List<string>
        {
            $"Substitute x = {x}: {substitutedFunc.Replace("+-", "-")}"
        };

        foreach (string term in terms)
        {
            string cleanTerm = term.Trim();
            double parsedTerm;

            if (cleanTerm.Contains("^"))
            {
                string[] parts = cleanTerm.Split('^');
                double baseValue = double.Parse(parts[0]);
                double exponent = double.Parse(parts[1]);
                double powerResult = Math.Pow(baseValue, exponent);

                if (baseValue < 0) powerResult *= -1;

                result += powerResult;
                steps.Add($"Calculate {baseValue}^{exponent} = {powerResult}");
            }
            else if (cleanTerm.Contains("*"))
            {
                string[] parts = cleanTerm.Split('*');
                double left = double.Parse(parts[0]);
                double right = double.Parse(parts[1]);
                double product = left * right;

                result += product;
                steps.Add($"Calculate {left}*{right} = {product}");
            }
            else if (double.TryParse(cleanTerm, out parsedTerm))
            {
                result += parsedTerm;
                steps.Add($"Add constant {parsedTerm}");
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
