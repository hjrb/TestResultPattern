using TestResultPattern;
namespace TestProject1;


[TestClass]
public class UnitTest1
{
	TestFluentResults testRunnerInstance=new TestFluentResults();

	public void Setup(double complexSolutionPercentage)
	{
		testRunnerInstance = new();
		testRunnerInstance.N = 1000;
		testRunnerInstance.ComplexSolutionPercentage = complexSolutionPercentage;
		testRunnerInstance.Setup();
		//Console.WriteLine($"Complex ratio: {complexRatio}, Desired ratio: {complexSolutionPercentage}");
	}

	[TestMethod]
	[DataRow(0.0)]
	[DataRow(0.1)]
	[DataRow(0.5)]
	public void TestMethodQuadraticEquation(double complexRatio)
	{
		Setup(complexRatio);
		var expected=testRunnerInstance.ComplexSolutionPercentage*testRunnerInstance.N;
		testRunnerInstance.BenchmarkQuadraticEquationUsingResult();
		Assert.IsTrue(testRunnerInstance.failCounterResult <= expected);
		testRunnerInstance.BenchmarkQuadraticEquationUsingException();
		Assert.IsTrue(testRunnerInstance.failCounterException <= expected);
		testRunnerInstance.BenchmarkQuadraticEquationUsingBoolAndOut();
		Assert.IsTrue(testRunnerInstance.failCounterBoolAndOut <= expected);

		Assert.IsTrue(testRunnerInstance.failCounterResult == testRunnerInstance.failCounterException && testRunnerInstance.failCounterException == testRunnerInstance.failCounterBoolAndOut);
	}

}