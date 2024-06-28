namespace DParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "1+2*((23-3)/5))";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var expression = parser.Parse();
            var result = expression.Evaluate();

            Console.WriteLine(expression.ToString());
            Console.WriteLine($"Input: '{input}' Result: {result}");
        }
    }
}
