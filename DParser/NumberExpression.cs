namespace DParser
{
    public class NumberExpression : Expression
    {
        public int Value { get; }

        public NumberExpression(int value)
        {
            this.Value = value;
        }

        public override int Evaluate()
        {
            return Value;
        }
    }
}
