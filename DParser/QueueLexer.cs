namespace DParser
{
    public class QueueLexer : ILexer
    {
        private Queue<Token> tokenQueue = new Queue<Token>();

        public QueueLexer(ILexer lexer)
        {
            for (var token = lexer.GetNext(); token.Type != TokenType.EOS; token = lexer.GetNext())
            {
                tokenQueue.Enqueue(token);
            }
        }

        public Token GetNext()
        {
            return tokenQueue.Dequeue();
        }

        public Token Peek()
        {
            if (tokenQueue.Count == 0)
            {
                return new Token(TokenType.EOS);
            }
            else
            {
                return tokenQueue.Peek();
            }
        }
    }
}
