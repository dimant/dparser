namespace DParser.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void JustANumber()
        {
            string input = "1";
            var lexer = new RegexLexer(input);
            var parser = new VaughnParser(lexer);
            var expression = parser.Parse();
            var result = expression.Evaluate();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SimpleCalculation()
        {
            string input = "1+1";
            var lexer = new RegexLexer(input);
            var parser = new VaughnParser(lexer);
            var expression = parser.Parse();
            var result = expression.Evaluate();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void PrecedenceCalculation()
        {
            string input = "1+1*3";
            var lexer = new RegexLexer(input);
            var parser = new VaughnParser(lexer);
            var expression = parser.Parse();
            var result = expression.Evaluate();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void BracesCalculation()
        {
            string input = "(1+1)*3";
            var lexer = new RegexLexer(input);
            var parser = new VaughnParser(lexer);
            var expression = parser.Parse();
            var result = expression.Evaluate();

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ComplexCalculation()
        {
            string input = "1+2*((23-3)/5))";
            var lexer = new RegexLexer(input);
            var parser = new VaughnParser(lexer);
            var expression = parser.Parse();
            var result = expression.Evaluate();

            Assert.AreEqual(9, result);
        }

    }
}
