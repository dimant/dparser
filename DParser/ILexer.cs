namespace DParser
{
    public interface ILexer
    {
        Token GetNext();

        Token Peek();
    }
}