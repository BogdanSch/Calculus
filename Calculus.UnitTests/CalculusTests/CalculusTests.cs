using FluentAssertions;
using System.Reflection.Metadata;

namespace Calculus.UnitTests.CalculusTests;
public class CalculusTests
{
    [Fact]
    public void Calculus_DetermineParity_ReturnString()
    {
        int input = 25;
        const string expectedResult = "Odd";

        string result = Calculus.DetermineParity(input);

        result.Should().Be(expectedResult);
    }
    [Fact]
    public void Calculus_DeterminePrime_ReturnString()
    {
        int input = 17;
        const string expectedResult = "Prime";

        string result = Calculus.DeterminePrime(input);

        result.Should().Be(expectedResult);
    }
    [Fact]
    public void Calculus_DeterminePrimeFactors_ReturnString()
    {
        int input = 56;
        const string expectedResult = "2^3 * 7";

        string result = Calculus.DeterminePrimeFactors(input);

        result.Should().Be(expectedResult);
    }
    [Fact]
    public void Calculus_DetermineGCD_ReturnInt()
    {
        int input1 = 48, input2 = 18;
        const int expectedResult = 6;

        int result = Calculus.DetermineGCD(input1, input2);

        result.Should().Be(expectedResult);
    }
    [Fact]
    public void Calculus_DetermineLCM_ReturnInt()
    {
        int input1 = 15, input2 = 20;
        const int expectedResult = 60;

        int result = Calculus.DetermineLCM(input1, input2);

        result.Should().Be(expectedResult);
    }
    [Fact]
    public void Calculus_EvaluateEulerTotient_ReturnInt()
    {
        int input1 = 12;
        const int expectedResult = 4;

        int result = Calculus.EvaluateEulerTotient(input1);

        result.Should().Be(expectedResult);
    }
    [Fact]
    public void Calculus_EvaluateFunctionByValue_ReturnDouble()
    {
        Func<double, double> func = (double x) => Math.Pow(x, 2) + 2 * x + 1;
        string funcDescription = "x^2 + 2*x + 1";
        double x = 3;
        const double expectedResult = 16.0;

        (double result, List<string> explanationSteps) =
            Calculus.EvaluateFunctionByValue(func, funcDescription, x);

        expectedResult.Should().Be(result);
        explanationSteps.Should().Contain(new[] { "The value 3 is within the functions domain.",
            "Evaluating function f(x) = x^2 + 2*x + 1",
            "Substitute x = 3: 3^2+2*3+1",
            "Calculate 3^2 = 9",
            "Calculate 2*3 = 6",
            "Add constant 1",
            "Final result: 16" });
    }
}
