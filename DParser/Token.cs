namespace DParser
{
    public enum TokenType
    {
        Number,
        Plus,
        Minus,
        Times,
        Divide,
        LeftBrace,
        RightBrace,
        EOS             // end of statement
    };

    public class Token
    {
        public TokenType Type { get; }

        public string? Value { get; }

        public Token(TokenType type, string? value = null)
        {
            Type = type;
            Value = value;
        }
    }
}
