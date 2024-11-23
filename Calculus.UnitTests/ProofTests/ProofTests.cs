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
            "Step 1: Let's divide 6 by 2 = 3.",
            "Step 2: The number 6 is divisible by 2."
        );
    }
}
