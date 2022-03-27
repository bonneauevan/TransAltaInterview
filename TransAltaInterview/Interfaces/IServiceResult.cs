namespace TransAltaInterview.Interfaces
{
    public interface IServiceResult
    {

        string Message { get; }

        bool HasError { get; }

        Exception Exception { get; }
    }

    public interface IServiceResult<T>: IServiceResult
    {
        T Result { get; }
    }
}
