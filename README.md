# Fruit Calculator

- Developed under the assumption that for a given basket item `itemPrice` and `itemCount` are non-negative values, a negative value could potentially invalidate the price calculation, in this case we would likley show the user an error along the lines of 'Please contact cusomter service' in the calling application.
- Took a functional approach using C# extension methods that rely on null-coalescing and null-conditional operators rather than a try-catch heavy asynchronous `Task.WhenAll()` approach.
- Utilized the `[DataTestMethod]` attribute tag to share test logic for given `[DataRow]` and created a enum to lookup mock data by index for readability.
- Implemented a simple .net core dependency injection design pattern for my `ILogger` class and verified it's calls using `Moq` just to demonstrate IoC comprehension. 
