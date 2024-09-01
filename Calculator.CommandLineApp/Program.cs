using CalcLib = Calculator.ClassLibrary;

namespace Calculator.CommandLineApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InspectArgumentsAndPerformActions(args);
        }

        private static void InspectArgumentsAndPerformActions(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    WriteInstructions();
                    break;
                case 3:
                    string result = PerformActions(float.Parse(args[0]), args[1], float.Parse(args[2]));
                    Console.WriteLine(result);
                    break;
                default:
                    Console.WriteLine("Only three arguments are supported");
                    WriteInstructions();
                    break;
            }
        }

        private static string PerformActions(float firstNumber, string operationToPerform, float secondNumber)
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
}
