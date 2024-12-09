using TestResultPattern;
namespace TestProject1;


[TestClass]
public class UnitTest1
{
    TestFluentResults testRunnerInstance=new TestFluentResults();

    public void Setup(double complexSolutionPercentage)
    {
        testRunnerInstance = new ();
        testRunnerInstance.N = 1000;
        testRunnerInstance.ComplexSolutionPercentage = complexSolutionPercentage;
        var complexRatio=testRunnerInstance.Setup();
        Console.WriteLine($"Complex ratio: {complexRatio}, Desired ratio: {complexSolutionPercentage}");
    }
    
    [TestMethod]
    public void TestMethodNoComplex()
    {
        Setup(0.0);
        var expected=testRunnerInstance.ComplexSolutionPercentage*testRunnerInstance.N;
        testRunnerInstance.BenchmarkQuadraticEquationUsingResult();
        Assert.IsTrue(testRunnerInstance.failCounterResult<=expected);
        testRunnerInstance.BenchmarkQuadraticEquationUsingException();
        Assert.IsTrue(testRunnerInstance.failCounterException <= expected);
        testRunnerInstance.BenchmarkQuadraticEquationUsingBoolAndOut();
        Assert.IsTrue(testRunnerInstance.failCounterBoolAndOut <= expected);

        Assert.IsTrue(testRunnerInstance.failCounterResult == testRunnerInstance.failCounterException && testRunnerInstance.failCounterException==testRunnerInstance.failCounterBoolAndOut);
    }

    [TestMethod]
    public void TestMethodTenPercent()
    {
        Setup(0.1);
        var expected = testRunnerInstance.ComplexSolutionPercentage * testRunnerInstance.N;
        testRunnerInstance.BenchmarkQuadraticEquationUsingResult();
        Assert.IsTrue(testRunnerInstance.failCounterResult <= expected);
        testRunnerInstance.BenchmarkQuadraticEquationUsingException();
        Assert.IsTrue(testRunnerInstance.failCounterException <= expected);
        testRunnerInstance.BenchmarkQuadraticEquationUsingBoolAndOut();
        Assert.IsTrue(testRunnerInstance.failCounterBoolAndOut <= expected);
        Assert.IsTrue(testRunnerInstance.failCounterResult == testRunnerInstance.failCounterException && testRunnerInstance.failCounterException == testRunnerInstance.failCounterBoolAndOut);
 
    } 
    
}