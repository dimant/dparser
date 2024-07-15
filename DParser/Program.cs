namespace DParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "1 + 2 * 23-3 / 5";
            //string input = "1+2+3+4+5";
            var lexer = new RegexLexer(input);
            var parser = new VaughnParser(lexer);
            var expression = parser.Parse();
            var result = expression.Evaluate();

            Console.WriteLine(expression.ToString());
            Console.WriteLine($"Input: '{input}' Result: {result}");
        }
    }
}
