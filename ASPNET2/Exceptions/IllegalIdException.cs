namespace ASPNET2.Exceptions;

[Serializable]
public class IllegalIdException : System.Exception
{
    public IllegalIdException(): base(){}
    public IllegalIdException(string message) : base(message)
    {

    }
}
