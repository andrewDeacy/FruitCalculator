using System.Collections.Generic;
using FruitCalculator.Models;

namespace FruitCalculator
{
    public class FruitCalculator : IFruitCalculator
    {
        private readonly ILogger _logger;

        public FruitCalculator(ILogger logger)
        {
            _logger = logger;
        }

        public double CalculateBasketTotal(Basket basket)
        {
            // I took the assumption that for a given basket item:
            // itemPrice > 0 (non-negative) & itemCount > 0 (non-negative)
            var price = basket?.CalculateBasketPrice(_logger) ?? 0.0;
            return price;
        }
    }

    public interface IFruitCalculator
    {
        double CalculateBasketTotal(Basket basket);
    }
}