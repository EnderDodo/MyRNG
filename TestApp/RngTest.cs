using MyRng;

namespace TestApp;

public class RngTest
{

    [Test]
    public void SufficientAmountInBothArrays()
    {
        var coefficients = new byte[] { 22, 48, 19, 76 };
        var values = new byte[] { 13, 64, 98 };

        var myRandom = new MyRandom(coefficients, values);
        var b = myRandom.Next();
        Assert.That(b, Is.LessThan(256));
    }
    
    [Test]
    public void CoefficientsAmountInsufficient()
    {
        var coefficients = new byte[] { 22, 48 };
        var values = new byte[] { 13, 64, 98 };

        var myRandom = new MyRandom(coefficients, values);
        var b = myRandom.Next();
        Assert.That(b, Is.LessThan(256));
    }
    
    [Test]
    public void ValuesAmountInsufficient()
    {
        var coefficients = new byte[] { 22, 48, 19, 76 };
        var values = new byte[] { 13, 64 };

        var myRandom = new MyRandom(coefficients, values);
        var b = myRandom.Next();
        Assert.That(b, Is.LessThan(256));
    }
}