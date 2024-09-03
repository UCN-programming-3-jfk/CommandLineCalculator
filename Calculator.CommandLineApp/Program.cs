using CalcLib = Calculator.ClassLibrary;
namespace Calculator.CommandLineApp;
internal class Program
{
    static void Main(string[] args)
    {
        InspectArgumentsAndPerformActions(args);
    }

    private static void InspectArgumentsAndPerformActions(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            WriteInstructions();
            return;
        }
        string result = PerformActionsAndReturnResult(float.Parse(args[0]), args[1], float.Parse(args[2]));
        Console.WriteLine(result);
    }

    private static string PerformActionsAndReturnResult(float firstNumber, string operationToPerform, float secondNumber)
    {
        switch (operationToPerform)
        {
            case "+":
                return $"{firstNumber} {operationToPerform} {secondNumber} = {CalcLib.Calculator.Add(firstNumber, secondNumber)}";
            case "-":
                return $"{firstNumber} {operationToPerform} {secondNumber} = {CalcLib.Calculator.Subtract(firstNumber, secondNumber)}";
            case "*":
                return $"{firstNumber} {operationToPerform} {secondNumber} = {CalcLib.Calculator.Multiply(firstNumber, secondNumber)}";
            case "/":
                return $"{firstNumber} {operationToPerform} {secondNumber} = {CalcLib.Calculator.Divide(firstNumber, secondNumber)}";
            default:
                return $"Unknown operator {operationToPerform}";
        }
    }

    private static void WriteInstructions()
    {
        Console.WriteLine("COMMAND LINE CALCULATOR");
        Console.WriteLine("Usage: CommandLineCalculator.exe [first number] [operation] [second number]");
        Console.WriteLine("Example: CommandLineCalculator.exe 4.5 * 3");
    }
}
