using System;
using Microsoft.AspNetCore.Builder;

namespace Elune.Sentry
{
    public static class AppBuilderExtensions
    {
        /// <summary>
        ///     Adds Sentry error reporting middleware to the request pipeline.
        /// </summary>
        /// <param name="applicationBuilder">The application builder.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">applicationBuilder</exception>
        public static IApplicationBuilder UseSentry(this IApplicationBuilder applicationBuilder)
        {
            if (applicationBuilder == null)
                throw new ArgumentNullException(nameof(applicationBuilder));

            return applicationBuilder.UseMiddleware<SentryMiddleware>();
        }
    }
}