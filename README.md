# Elune.Sentry
This repository contains an ASP.NET Core middleware component used by Elune to capture unhandled exceptions, and report them to Sentry.

## Usage
Add the following to your `appSettings.json`:

```
  "Sentry": {
    "Dsn": "{your_DSN_here}"
  }
```

Then, in `ConfigureServices`:

```csharp
    services.Configure<SentryOptions>(Configuration.GetSection("Sentry"));
```

Register the error reporter with the DI container:
```csharp
services.AddScoped<IErrorReporter, SentryErrorReporter>();
```

Finally, in `Configure`:

```csharp
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSentry();

            app.UseMvc();
```

Keep in mind the order of middleware in the request pipeline. Requests travel through the pipeline back and forth initially, and then in reverse order afterwards.

Since this middleware component does not handle any exceptions (it only logs them, then passes them to other handlers), you'll want to place the Sentry middleware component before any other middleware components that handle exceptions. 

## License
This code is licensed under the Apache License 2.0. Libraries included in the code may be licensed differently. Please respect all licenses.