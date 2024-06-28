namespace DParser
{
    public class BinaryExpression : Expression
    {
        public Expression Left { get; }

        public Token Opertator { get; }

        public Expression Right { get; }

        private Dictionary<TokenType, Func<int, int, int>> operations = new Dictionary<TokenType, Func<int, int, int>>()
        {
            { TokenType.Plus,    (a, b) => a + b },
            { TokenType.Minus,   (a, b) => a - b },
            { TokenType.Times,   (a, b) => a * b },
            { TokenType.Divide,  (a, b) => a / b },
        };

        public BinaryExpression(Expression left, Token opertator, Expression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Opertator = opertator ?? throw new ArgumentNullException(nameof(opertator));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public override int Evaluate()
        {
            if (operations.ContainsKey(Opertator.Type) == false)
            {
                throw new ParserException($"Unknown operator: {Opertator.Type}");
            }

            return operations[this.Opertator.Type](Left.Evaluate(), Right.Evaluate());
        }

        public override string ToString()
        {
            return $"({ Left.ToString() } { Opertator.Value } { Right.ToString() })";
        }
    }
}
