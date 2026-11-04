using static System.Console;
internal class Program
{
    private static void Main(string[] args)
    {
        WriteLine("Hello, World!");

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
                    "1" => Addition,
                    "2" => Subtraction,
                    "3" => Multiplication,
                    "4" => Division,
                    _ => () => WriteLine("Invalid option")
                };

                option();

            } while (input != "0");
        
}
          Menu();


        // Get number from user
        int GetNumberFromUser(string prompt)
        {
            string? input;
            bool isNumber;

            do
            {
                WriteLine(prompt);
                input = ReadLine();

                isNumber = (Int32.TryParse(input, out int number));
                if (isNumber)
                {
                    return number;
                }
                else
                {
                    WriteLine($"{input} is not a number, please enter a valid number\n");
                }
            } while (true);

        }


        // Actions
        void Addition()
        {
            // Clear console
            Clear();
           
            int numA, numB;

            numA = GetNumberFromUser("Enter first number");
            numB = GetNumberFromUser("Enter second number");

            WriteLine($"{numA} + {numB} = {numA + numB}");

            WriteLine("\nPress any key to continue...");
            ReadKey();
            Clear();

        }

        void Subtraction()
        {
            Clear();

            int numA, numB;

            numA = GetNumberFromUser("Enter first number");
            numB = GetNumberFromUser("Enter second number");

            WriteLine($"{numA} - {numB} = {numA - numB}");

            WriteLine("\nPress any key to continue...");
            ReadKey();
            Clear();
        }

        void Multiplication()
        {
            Clear();

            int numA, numB;

            numA = GetNumberFromUser("Enter first number");
            numB = GetNumberFromUser("Enter second number");

            WriteLine($"{numA} * {numB} = {numA * numB}");

            WriteLine("\nPress any key to continue...");
            ReadKey();
            Clear();
        }

        void Division()
        {
            Clear();

            float numA, numB;

            numA = GetNumberFromUser("Enter dividend number");

            do
            {
                numB = GetNumberFromUser("Enter divisor number");

                if (numB == 0)
                {
                    WriteLine("Divisor can't be zero");
                }

            } while (numB == 0);

            WriteLine($"{numA} / {numB} = {(numA / numB)}");

            WriteLine("\nPress any key to continue...");
            ReadKey();
            Clear();
        }

        void ExitProgram()
        {
            // Ended execution, show finish message 
            WriteLine("Press any key to close...");
            ReadKey();

        }
    }
}