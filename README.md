# ASP.NET option pattern demo

This is a demo app to show the difference between `IOptionsMonitor`, `IOptions`
and `IOptionsSnapshot`.

- IOptionsMonitor: always return the new value
- IOptions: always return the old value until the app is restarted
- IOptionsSnapshot: return the new value if it is a new request

```c#
string name1 = _optionsMonitor.CurrentValue.Name;
string name2 = _options.Value.Name;
string name3 = _optionsSnapshot.Value.Name;
```

For more information about ASP.NET option pattern, please read 
[this doc](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-5.0).

## Tech stack

Visual Studio 2019 and ASP.NET 5