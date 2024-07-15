namespace DParser
{
    public class RecursiveDescentParser : IParser
    {
        private ILexer lexer;

        public RecursiveDescentParser(ILexer lexer)
        {
            this.lexer = lexer ?? throw new ArgumentNullException(nameof(lexer));
        }

        private Expression ParseFactor()
        {
            if (lexer.Peek().Type == TokenType.LeftBrace)
            {
                lexer.GetNext(); // consume (
                var result = ParseSum();
                if (lexer.Peek().Type != TokenType.RightBrace)
                {
                    throw new InvalidOperationException($"Expected ')' but got: '{lexer.Peek().Value}'");
                }
                lexer.GetNext(); // consume )

                return result;
            }
            else if (lexer.Peek().Type == TokenType.Number)
            {
                var token = lexer.GetNext();
                return new NumberExpression(int.Parse(token.Value));
            }
            else
            {
                throw new InvalidOperationException($"Unexpected token: {lexer.Peek().Value}");
            }
        }

        private Expression ParseSum()
        {
            var result = ParseProduct();

            while (lexer.Peek().Type == TokenType.Plus ||  lexer.Peek().Type == TokenType.Minus)
            {
                var op = lexer.GetNext();
                var right = ParseProduct();
                result = new BinaryExpression(result, op, right);
            }

            return result;
        }

        private Expression ParseProduct()
        {
            var result = ParseFactor();

            while (lexer.Peek().Type == TokenType.Times || lexer.Peek().Type == TokenType.Divide)
            {
                var op = lexer.GetNext();
                var right = ParseFactor();
                result = new BinaryExpression(result, op, right);
            }

            return result;
        }

        public Expression Parse()
        {
            return ParseSum();
        }
    }
}
