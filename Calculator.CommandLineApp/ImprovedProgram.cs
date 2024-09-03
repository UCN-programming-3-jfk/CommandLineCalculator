namespace Calculator.CommandLineApp;

using CalcLib = Calculator.ClassLibrary;

class ImprovedProgram
{
    static float firstNumber, secondNumber, result;
    static string operationToPerform;

    static void ImprovedMain(string[] args)
    {
        CheckInputAndExitIfInvalid(args);
        ParseInput(args[0], args[1], args[2]);
        CalculateResult();
        PrintResult();
    }
    private static void CheckInputAndExitIfInvalid(string[] args)
    {
        if (!ValidateInput(args))
        {
            WriteInstructions();
            
            // Exit the program with a non-zero exit code to signal an error
            Environment.Exit(-1);
        }
    }
    private static bool ValidateInput(string[] args)
    {
        //NOTE: arguments to a .NET program are also available through "Environment.CommandLine"

        // Check if the input is null or empty
        if (args == null || args.Length != 3) { return false; }
        
        // Check if the operator is one of the valid four options
        if (args[1] == "+" || args[1] == "-" || args[1] == "*" || args[1] == "/") { return false; }
        
        // Check if the first and second numbers are valid floats
        if (!float.TryParse(args[0], out float firstNumber) || !float.TryParse(args[2], out float secondNumber)) { return false; }
        
        return true; //valid input
    }
    private static void WriteInstructions()
    {
        Console.WriteLine("COMMAND LINE CALCULATOR");
        Console.WriteLine("Usage: CommandLineCalculator.exe [first number] [operation] [second number]");
        Console.WriteLine("Example: CommandLineCalculator.exe 4.5 * 3");
    }
    private static void ParseInput(string number1, string operation, string number2)
    {
        float.TryParse(number1, out firstNumber);
        float.TryParse(number2, out secondNumber);
        operationToPerform = operation;
    }
    private static void CalculateResult()
    {
        float result = 0;
        switch (operationToPerform)
        {
            case "+":
                result = CalcLib.Calculator.Add(firstNumber, secondNumber);
                return;
            case "-":
                result = CalcLib.Calculator.Subtract(firstNumber, secondNumber);
                return;
            case "*":
                result = CalcLib.Calculator.Multiply(firstNumber, secondNumber);
                return;
            case "/":
                result = CalcLib.Calculator.Divide(firstNumber, secondNumber);
                return;
            default:
                throw new InvalidOperationException($"Unknown operator {operationToPerform}");
        }
    }
    private static void PrintResult()
    {
        Console.WriteLine($"{firstNumber} {operationToPerform} {secondNumber} = {result}");
    }
}