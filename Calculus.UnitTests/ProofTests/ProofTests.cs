using FluentAssertions;

namespace Calculus.UnitTests.ProofTests;
public class ProofTests
{
    [Fact]
    public void Proof_DirectProof_ReturnListString()
    {
        int number = 6;

        List<string> actualProofSteps = Proof.DirectProof(number);

        actualProofSteps.Should().NotBeNullOrEmpty();
        actualProofSteps.Should().ContainInOrder(
            "Given number: 6",
            "Step 1: Since the number 6 is even, it can be written as n = 2k.",
            "Step 2: The number 6 is divisible by 2."
        );
    }
    [Fact]
    public void ProveSumOfOddNumbers_Should_ProveStatementCorrectly()
    {
        Func<int, int> calculateSumOfOddNumbers = (int n) =>
        {
            int sum = 1;
            for (int i = 3, count = 1; count < n; i += 2, count++)
            {
                sum += i;
            }
            return sum;
        };

        List<string> actualProofSteps = Proof.ProveSumOfOddNumbers(calculateSumOfOddNumbers);

        actualProofSteps.Should().NotBeNullOrEmpty();
        actualProofSteps.Should().Contain(step => step.Contains("Base case verified for n = 1."));
        actualProofSteps.Should().Contain(step => step.Contains("Assume the statement is true for n = k."));
        actualProofSteps.Should().Contain(step => step.Contains("Induction step verified for n = k + 1."));
        actualProofSteps.Should().EndWith("Conclusion: The statement is proven by induction.");
    }
}
