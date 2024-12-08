using TestResultPattern;
namespace TestProject1;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var a = new TestFluentResults();
        a.N = 1000;
        a.ComlexSolutionPercentage = 0.0;
        a.Setup();
        var expected=a.ComlexSolutionPercentage*a.N;
        a.BenchmarkQuadraticEquationUsingResult();
        Assert.IsTrue(a.failCounterResult<=expected);
        a.BenchmarkQuadraticEquationUsingException();
        Assert.IsTrue(a.failCounterException <= expected);
        a.BenchmarkQuadraticEquationUsingBoolAndOut();
        Assert.IsTrue(a.failCounterBoolAndOut <= expected);

        Assert.IsTrue(a.failCounterResult == a.failCounterException && a.failCounterException==a.failCounterBoolAndOut);

        a.ComlexSolutionPercentage = 0.1;
        a.Setup();
        expected = a.ComlexSolutionPercentage * a.N;
        a.BenchmarkQuadraticEquationUsingResult();
        Assert.IsTrue(a.failCounterResult <= expected);
        a.BenchmarkQuadraticEquationUsingException();
        Assert.IsTrue(a.failCounterException <= expected);
        a.BenchmarkQuadraticEquationUsingBoolAndOut();
        Assert.IsTrue(a.failCounterBoolAndOut <= expected);

        Assert.IsTrue(a.failCounterResult == a.failCounterException && a.failCounterException == a.failCounterBoolAndOut);
    }
}