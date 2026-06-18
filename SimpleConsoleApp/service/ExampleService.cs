using System.IO.Pipelines;

public class ExampleService : IExampleService
{
    
    public string performMultiplication(int a, int b)
    {
        return $"Result of multiplying {a} and {b}: {a * b}";
    }

    public string performAddition(int a, int b)
    {
        return $"Result of adding {a} and {b}: {a + b}";
    }

    public string performSubtraction(int a, int b)
    {
        return $"Result of subtracting {b} from {a}: {a - b}";
    }


}