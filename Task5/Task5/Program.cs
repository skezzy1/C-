using System;
using System.Threading.Tasks;

public class ParallelUtils<T, TR>
{
    private Func<T, T, TR> operation;
    private T operand1;
    private T operand2;

    public TR? Result { get; private set; }

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        this.operation = operation;
        this.operand1 = operand1;
        this.operand2 = operand2;

        Result = default(TR); 
    }

    public void StartEvaluation()
    {
        Task.Run(() =>
        {
            Result = operation(operand1, operand2);
        });
    }

    public void Evaluate()
    {
        Task.Run(() =>
        {
            Result = operation(operand1, operand2);
        }).Wait();
    }
}

public class Program
{
    public static void Main(string[] args) { 
        ParallelUtils<int, int> intUtils = new ParallelUtils<int, int>((a, b) => a + b, 5, 7);
        intUtils.StartEvaluation();
        intUtils.Evaluate();
        Console.WriteLine($"Result of adding integers: {intUtils.Result}");

        ParallelUtils<string, string> stringUtils = new ParallelUtils<string, string>((a, b) => a + b, "Hello, ", "world!");
        stringUtils.StartEvaluation();
        stringUtils.Evaluate();
        Console.WriteLine($"Result of concatenating strings: {stringUtils.Result}");
    }
}
