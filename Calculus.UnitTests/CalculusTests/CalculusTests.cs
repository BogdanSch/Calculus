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
}
