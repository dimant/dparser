namespace DParser.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void SimpleAddition()
        {
            string input = "1+2";
            var expected = new Token[] {
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "2")
            };

            var lexer = new RegexLexer(input);

            var actual = new List<Token>();

            for (var token = lexer.GetNextToken(); token.Type != TokenType.EOS; token = lexer.GetNextToken())
            {
                actual.Add(token);
            }

            Assert.AreEqual(expected.Length, actual.Count, $"expected length: {expected.Length} actual length: {actual.Count}");

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Type, actual[i].Type);
                Assert.AreEqual(expected[i].Value, actual[i].Value);
            }
        }

        [TestMethod]
        public void MultiDigitNumber()
        {
            string input = "1+1234";
            var expected = new Token[] {
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "1234")
            };

            var lexer = new RegexLexer(input);

            var actual = new List<Token>();

            for (var token = lexer.GetNextToken(); token.Type != TokenType.EOS; token = lexer.GetNextToken())
            {
                actual.Add(token);
            }

            Assert.AreEqual(expected.Length, actual.Count, $"expected length: {expected.Length} actual length: {actual.Count}");

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Type, actual[i].Type);
                Assert.AreEqual(expected[i].Value, actual[i].Value);
            }
        }

        [TestMethod]
        public void WhiteSpace()
        {
            string input = "1   +   2";
            var expected = new Token[] {
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "2")
            };

            var lexer = new RegexLexer(input);

            var actual = new List<Token>();

            for (var token = lexer.GetNextToken(); token.Type != TokenType.EOS; token = lexer.GetNextToken())
            {
                actual.Add(token);
            }

            Assert.AreEqual(expected.Length, actual.Count, $"expected length: {expected.Length} actual length: {actual.Count}");

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Type, actual[i].Type);
                Assert.AreEqual(expected[i].Value, actual[i].Value);
            }
        }

        [TestMethod]
        public void ComplexExpression()
        {
            string input = "1+2*(3-(4/5))";
            var expected = new Token[] {
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Plus, "+"),
                new Token(TokenType.Number, "2"),
                new Token(TokenType.Times, "*"),
                new Token(TokenType.LeftBrace, "("),
                new Token(TokenType.Number, "3"),
                new Token(TokenType.Minus, "-"),
                new Token(TokenType.LeftBrace, "("),
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Divide, "/"),
                new Token(TokenType.Number, "5"),
                new Token(TokenType.RightBrace, ")"),
                new Token(TokenType.RightBrace, ")"),
            };

            var lexer = new RegexLexer(input);

            var actual = new List<Token>();

            for (var token = lexer.GetNextToken(); token.Type != TokenType.EOS; token = lexer.GetNextToken())
            {
                actual.Add(token);
            }

            Assert.AreEqual(expected.Length, actual.Count, $"expected length: {expected.Length} actual length: {actual.Count}");

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Type, actual[i].Type);
                Assert.AreEqual(expected[i].Value, actual[i].Value);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void SyntaxError()
        {
            string input = "1+2*(x-(4/5))";

            var lexer = new RegexLexer(input);

            var actual = new List<Token>();

            for (var token = lexer.GetNextToken(); token.Type != TokenType.EOS; token = lexer.GetNextToken())
            {
                actual.Add(token);
            }
        }
    }
}