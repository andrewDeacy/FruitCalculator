using Microsoft.Extensions.DependencyInjection;

namespace FruitCalculator
{
    public static class CalculatorConfiguration
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddSingleton<ILogger, Logger>()
                .AddSingleton<IFruitCalculator, FruitCalculator>()
                .BuildServiceProvider();
        }

    }
}