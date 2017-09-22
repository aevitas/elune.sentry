using System;
using System.Threading.Tasks;

namespace Elune.Sentry
{
    /// <summary>
    ///     Interface all types representing an error reporter should implement.
    /// </summary>
    public interface IErrorReporter
    {
        /// <summary>
        ///     Captures the specified exception asynchronously and hands it off to an error handling service.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        Task CaptureAsync(Exception exception);

        /// <summary>
        ///     Captures the specified message asynchronously and hands it off to an error handling service.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task CaptureAsync(string message);
    }
}
