namespace DParser
{
    public class VaughnParser : IVaughnParser
    {
        private RegexLexer lexer;

        private Token lookAheadToken;

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

        public VaughnParser(RegexLexer lexer)
        {
            this.lexer = lexer ?? throw new ArgumentNullException(nameof(lexer));
            this.lookAheadToken = lexer.GetNextToken();
        }

        public Expression Parse()
        {
            return ParseExpression(0);
        }

        private Expression ParseExpression(int precedence)
        {
            var left = ParsePrimary();

            while (precedence < GetPrecedence(lookAheadToken))
            {
                var currentToken = lookAheadToken;
                lookAheadToken = lexer.GetNextToken();
                left = ParseBinaryExpression(left, currentToken);
            }

            return left;
        }

        private Expression ParsePrimary()
        {
            var currentToken = lookAheadToken;
            lookAheadToken = lexer.GetNextToken();

            switch (currentToken.Type)
            {
                case TokenType.Number:
                    return new NumberExpression(int.Parse(currentToken.Value ?? "0"));
                case TokenType.LeftBrace:
                    var expression = ParseExpression(0);
                    lookAheadToken = lexer.GetNextToken();
                    return expression;
                default:
                    throw new ParserException($"Unexpected token type: {currentToken.Type} '{currentToken.Value}'");
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
