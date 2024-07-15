namespace DParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "(1 + 2) * 4";
            //string input = "1+2+3+4+5";
            var lexer = new QueueLexer(new RegexLexer(input));
            //var parser = new VaughnParser(lexer);
            var parser = new RecursiveDescentParser(lexer);
            var expression = parser.Parse();
            var result = expression.Evaluate();

            Console.WriteLine(expression.ToString());
            Console.WriteLine($"Input: '{input}' Result: {result}");
        }
    }
}
