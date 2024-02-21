namespace FileGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Nombre del archivo CSV
            string filePath = "operaciones.txt";
            string outputFilePath = "resultado.txt";

            // Número de líneas a generar
            int numberOfLines = 20;

            // Creamos un objeto StreamWriter para escribir en el archivo CSV
            using (StreamWriter writer = new StreamWriter(filePath))
            using (StreamWriter writerResult = new StreamWriter(outputFilePath))
            {
                // Generamos las líneas y las escribimos en el archivo
                Random random = new Random();

                for (int i = 0; i < numberOfLines; i++)
                {
                    // Genera un número decimal aleatorio entre 0 y 10 , redondeado a 2 decimales
                    double number1 = Math.Round(random.NextDouble() * 10, 2);
                    double number2 = Math.Round(random.NextDouble() * 10, 2);

                    // Genera un número entero aleatorio entre 0 y 99
                    int iNumber1 = random.Next(100);
                    int iNumber2 = random.Next(100);

                    string[] operators = { "+", "-", "*", "/" };

                    // Selecciona aleatoriamente un operador matemático para datos decimales
                    string decimalOperator = operators[random.Next(operators.Length)];

                    // Selecciona aleatoriamente un operador matemático para datos enteros
                    string integerOperator = operators[random.Next(operators.Length)];

                    // Selecciona aleatoriamente un operador matemático para las letras
                    string charOperator = operators[random.Next(operators.Length)];

                    // Realiza la operación matemática para decimales
                    double result = PerformDecimalOperation(number1, number2, decimalOperator);

                    // Realiza la operación matemática para enteros
                    int iResult = PerformIntegerOperation(iNumber1, iNumber2, integerOperator);

                    // Formatea la línea según el formato especificado
                    // Para más información => https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
                    string lineDecimal = $"{number1:F2}{decimalOperator}{number2:F2}";
                    string resultDecimal = $"{result:F2}";

                    string lineInteger = $"{iNumber1}{integerOperator}{iNumber2}";
                    string resultInteger = $"{iResult}";

                    string lineInvalid = $"{GetLetter()}{charOperator}{GetLetter()}";
                    string resultChar = $"?";

                    // Escribe la línea en el archivo de operaciones
                    writer.WriteLine(lineDecimal);
                    writer.WriteLine(lineInteger);
                    writer.WriteLine(lineInvalid);

                    // Escribe la línea en el archivo de resultado
                    writerResult.WriteLine(resultDecimal);
                    writerResult.WriteLine(resultInteger);
                    writerResult.WriteLine(resultChar);

                }
            }

            Console.WriteLine($"Se ha generado el archivo CSV: \n1.{filePath}\n2.{outputFilePath}");
        }

        static int PerformIntegerOperation(int num1, int num2, string op)
        {
            switch (op)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                case "%":
                    return num1 % num2;
                case "pow":
                    return (int)Math.Pow(num1, num2);//posible perdidad de datos al usar int
                default:
                    throw new ArgumentException("Operador no válido");
            }
        }

        static double PerformDecimalOperation(double num1, double num2, string op)
        {
            switch (op)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                case "%":
                    return num1 % num2;
                case "pow":
                    return Math.Pow(num1, num2);
                default:
                    throw new ArgumentException("Operador no válido");
            }
        }

        public static char GetLetter()
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length);
            return chars[num];
        }
    }
}
