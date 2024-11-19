using FluentAssertions;

namespace Calculus.UnitTests.ProofTests;
public class ProofTests
{
    [Fact]
    public void Proof_DirectProof_ReturnString()
    {
        int number = 6;

        List<string> actualProofSteps = Proof.DirectProof(number);

        actualProofSteps.Should().ContainInOrder(
            "Given number: 6",
            "Step 1: Since the number 6 is even, it can be written as n = 2k.",
            "Step 2: The number 6 is divisible by 2."
        );
    }
    [Fact]
    public void ProveSumOfOddNumbers_Should_ProveStatementCorrectly()
    {
        // Arrange
        var expectedProofSteps = new List<string>
        {
            "Proof by induction for the statement: 'The sum of the first n odd numbers is n^2 for all positive integers n.'",
            "Step 1: Base Case",
            "For n = 1, sum = 1 and n^2 = 1. Base case verified!",
            "\nStep 2: Induction Hypothesis",
            "Assume the statement is true for n = k, i.e., sum of first k odd numbers is k^2.",
            "\nStep 3: Induction Step",
            "We need to prove that the statement holds for n = k + 1.",
            "That is, sum of first (k + 1) odd numbers = (k + 1)^2.",
            "\nStep 3.1: Using the induction hypothesis:",
            "Sum of first k odd numbers = k^2 (by induction hypothesis).",
            "Adding the (k + 1)-th odd number (2k + 1):",
            "Sum of first (k + 1) odd numbers = k^2 + (2k + 1)",
            "Simplify: k^2 + (2k + 1) = (k + 1)^2 using a^2 + 2ab + b^2 = (a + b)^2.",
            "Thus, the statement is true for n = k + 1.",
            "\nConclusion: The statement is proven by induction to be true for all positive integers n."
        };

        // Act
        var actualProofSteps = Proof.ProveSumOfOddNumbers();

        // Assert
        actualProofSteps.Should().BeEquivalentTo(expectedProofSteps, options => options.WithStrictOrdering());
    }
}
