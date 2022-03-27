using TransAltaInterview.Interfaces;
using System;

namespace TransAltaInterview.Models
{
    /// <summary>
    /// Class that represents the return object from a service.
    /// </summary>
    public class ServiceResult: IServiceResult
    {
        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public ServiceResult()
        {
        }

        /// <summary>
        /// Create an instance of the ServiceResult class.
        /// </summary>
        /// <param name="ex">Exception if any</param>
        /// <param name="message">Message (for user presentation)</param>
        public ServiceResult(Exception ex = null, string message = null) : base()
        {
            Exception = ex;
            Message = message;
        }

        /// <summary>
        /// Message to display to the user.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Indicate if there is an exception in the result.
        /// </summary>
        public bool HasError => Exception != null;

        /// <summary>
        /// Exception returned as part of the result
        /// </summary>
        public Exception Exception { get; }
    }

    /// <summary>
    /// Class that represents the return object from a service. Includes a specific result of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T>: ServiceResult, IServiceResult<T>
    {
        /// <summary>
        /// Result returned a part of the service result.
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Create an instance of the ServiceResult class.
        /// </summary>
        /// <param name="result">The result of type T to return</param>
        /// <param name="ex">Error if any</param>
        /// <param name="message">User readable message</param>
        public ServiceResult(T result, Exception ex = null, string message = null) : base(ex, message)
        {
            Result = result;
        }

        /// <summary>
        /// Create an instance of the ServiceTaskResult class.
        /// </summary>
        /// <param name="result">The result of type T to return</param>
        /// <param name="existingResult">Untyped IServiceTaskResult</param>
        public ServiceResult(T result, IServiceResult existingResult) : base(existingResult.Exception, existingResult.Message)
        {
            Result = result;
        }
    }
}
