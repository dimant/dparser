using System.Text.RegularExpressions;

namespace DParser
{
    public class RegexLexer : ILexer
    {
        private string input;

        private int offset;

        private readonly List<(string, TokenType)> tokenPatterns = new List<(string, TokenType)>()
        {
            (@"\+",    TokenType.Plus),
            (@"-",     TokenType.Minus),
            (@"\*",    TokenType.Times),
            (@"/",     TokenType.Divide),
            (@"\(",    TokenType.LeftBrace),
            (@"\)",    TokenType.RightBrace),
            (@"\d+",   TokenType.Number)
        };

        public RegexLexer(string input)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
            this.offset = 0;
        }

        private bool MatchAtOffset(string input, int offset, string pattern, out string output)
        {
            if (offset < 0 || offset >= input.Length)
            {
                output = string.Empty;
                return false;
            }

            string substring = input.Substring(offset);

            Match match = Regex.Match(substring, $"^{pattern}");

            if (match.Success)
            {
                output = match.Value;
                return true;
            }
            else
            {
                output = string.Empty;
                return false;
            }
        }

        public Token GetNext()
        {
            while (offset < input.Length && char.IsWhiteSpace(input[offset]))
            {
                offset++;
            }

            if (offset == input.Length)
            {
                return new Token(TokenType.EOS);
            }

            string match = string.Empty;

            foreach ((string pattern, TokenType type) in tokenPatterns)
            {
                if (MatchAtOffset(input, offset, pattern, out match))
                {
                    offset += match.Length;
                    return new Token(type, match);
                }
            }

            throw new ParserException($"Unexpected token at offset {offset}: '{input}'");
        }

        public Token Peek()
        {
            throw new NotImplementedException();
        }
    }
}
