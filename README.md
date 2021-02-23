# Exception Handling for ASP.NET Core

ActionResultExceptionHandler allows you to explicitly handle exception within your ASP.NET Core application, within each controller action.

Configuring your error handling this way reaps the following benefits:

- Simple and minimalist way to handle exceptions in your Asp.Net Core applications
- A more clean approach to try-catch logic in your controllers
- Catch and appropriately handle specific or non specified exceptions.

This Library targets the ASP.NET Core applications.

## Installation

ActionResultExceptionHandler is [available on NuGet](https://www.nuget.org/packages/Chibuike.Util.ActionResultExceptionHandler/) and can be installed via the below commands depending on your platform:

```
$ Install-Package Chibuike.Util.ActionResultExceptionHandler
```
or via the .NET Core CLI:

```
$ dotnet add package Chibuike.Util.ActionResultExceptionHandler
```

## Bare Bones Setup in your StartUp.cs

**Note:** This Exception handler has to be Injected using Asp.Net Core inbuilt functionality for dependency injection.

```csharp
// Startup.cs
using ActionResultExceptionHandler;

// This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ExceptionService>();

        services.AddControllers();
    }
```


## Handling specific exceptions in your Controller

You can explicitly handle exceptions like so:

```csharp
using ActionResultExceptionHandler;

    public class ValuesController : ControllerBase
    {
        public readonly ExceptionService _exceptionService;

        public ValuesController (ExceptionService exceptionService)
        {
            _exceptionService = exceptionService;
        }


        [HttpPost("{id}")]
        public ActionResult Get(Guid id)
        {  
            try
            {
                //do something: (Get values by Id)
            }
            catch(Exception ex)
            {
                return _exceptionService.GetActionResult(ex);
            }
        }
    }
```


## Sample Response for caught exceptions
```json
HTTP/1.1 404 Not Found
content-type: application/json; charset=utf-8 
date: Tue, 23 Feb 2021 17:03:03 GMT 
server: Kestrel

{
  "message": "Values with id does not exist",
  "stackTrace": "   at ValueSample.Controllers.ValuesController.Get(Guid id) in C:\\Users\\Chibuike\\source\\repos\\ValueSample\\Controllers\\ValuesController.cs:line 63",
  "data": {},
  "innerException": null
}
```
