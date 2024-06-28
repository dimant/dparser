namespace DParser
{
    public class Parser
    {
        private Lexer lexer;

        private Token currentToken;

        private Dictionary<TokenType, int> precedence = new Dictionary<TokenType, int>()
        {
            { TokenType.EOS,     0 },
            { TokenType.Number,  1 },
            { TokenType.Plus,    2 },
            { TokenType.Minus,   2 },
            { TokenType.Times,   3 },
            { TokenType.Divide,  3 }
        };

        private int GetPrecedence(Token token)
        {
            var type = token.Type;

            if (precedence.ContainsKey(type))
            {
                return precedence[type];
            }

            return 0;
        }

        public Parser(Lexer lexer)
        {
            this.lexer = lexer ?? throw new ArgumentNullException(nameof(lexer));
            this.currentToken = lexer.GetNextToken();
        }

        public Expression Parse()
        {
            return ParseExpression(0);
        }

        private Expression ParseExpression(int precedence)
        {
            var left = ParsePrimary();

            while (precedence < GetPrecedence(currentToken))
            {
                var token = currentToken;
                currentToken = lexer.GetNextToken();
                left = ParseBinaryExpression(left, token);
            }

            return left;
        }

        private Expression ParsePrimary()
        {
            var token = currentToken;
            currentToken = lexer.GetNextToken();

            switch (token.Type)
            {
                case TokenType.Number:
                    return new NumberExpression(int.Parse(token.Value ?? "0"));
                case TokenType.LeftBrace:
                    var expression = ParseExpression(0);
                    currentToken = lexer.GetNextToken();
                    return expression;
                default:
                    throw new ParserException($"Unexpected token type: {token.Type} '{token.Value}'");
            }
        }

        private Expression ParseBinaryExpression(Expression left, Token token)
        {
            var precedence = GetPrecedence(token);
            var right = ParseExpression(precedence);
            return new BinaryExpression(left, token, right);
        }
    }
}
