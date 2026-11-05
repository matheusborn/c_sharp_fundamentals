using static System.Console;
internal class Program
{
    private static void Main(string[] args)
    {

        // Show menu and handling function calls
        void Menu()
        {
            string? input;
            do
            {
                // Show options to user
                WriteLine("Calculator");
                WriteLine("Please, select an option:");
                WriteLine("1 - Addition");
                WriteLine("2 - Subtraction");
                WriteLine("3 - Multiplication");
                WriteLine("4 - Division");
                WriteLine("0 - Exit");

                // Get user's response
                input = ReadLine();
                Action option = input switch
                {
                    "0" => ExitProgram,
                    "1" => () => ExecuteOperation("Addition", (a, b) => a + b, "+"),
                    "2" => () => ExecuteOperation("Subtraction", (a, b) => a - b, "-"),
                    "3" => () => ExecuteOperation("Multiplication", (a, b) => a * b, "*"),
                    "4" => () => ExecuteOperation("Division", Divide, "/"),
                    _ => () => WriteLine("Invalid Option")
                };

                option();

            } while (input != "0");

        }
        Menu();


        // Get number from user
        float GetNumberFromUser(string prompt)
        {
            string? input;
            bool isNumber;

            while (true)
            {
                WriteLine(prompt);
                input = ReadLine()?.Replace(".", ",");

                isNumber = (float.TryParse(input, out float number));
                if (isNumber)
                {
                    return number;
                }
                else
                {
                    WriteLine($"{input} is not a number, please enter a valid number\n");
                }
            }
            ;

        }


        // Action
        void ExecuteOperation(
            string operationName,
            Func<float, float, float> operation,
            string symbol)
        {
            Clear();

            float a = GetNumberFromUser("Enter first number");
            float b = GetNumberFromUser("Enter second number");

            try
            {
                WriteLine($"{a} {symbol} {b} = {operation(a, b)}");
            }
            catch (DivideByZeroException)
            {
                WriteLine("Can't divide by zero");
            }

            WriteLine("\nPress any key...");
            ReadKey();
            Clear();
        }

        float Divide(float a, float b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }


        void ExitProgram()
        {
            // Ended execution, show finish message 
            WriteLine("Press any key to close...");
            ReadKey();

        }
    }
}