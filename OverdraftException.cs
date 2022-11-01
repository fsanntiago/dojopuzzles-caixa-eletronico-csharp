namespace CaixaEletronico;

public class OverdraftException : Exception
{
    public OverdraftException(string message)
        : base(message)
    {
    }
}