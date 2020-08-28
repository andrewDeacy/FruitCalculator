using System.Collections.Generic;
using System;
using FruitCalculator.Models;

namespace FruitCalculatorUnitTests
{
    public static class MockData
    {
        private static readonly Fruit MockApple = new Fruit {Name = "Apple", Price = 5};
        private static readonly Fruit MockOrange = new Fruit {Name = "Orange", Price = 10};
        private static readonly Fruit MockUnknownFruit = new Fruit {Name = null, Price = 2.0};

        public enum MockBasketItemIndex
        {
            TenFullPriceApples,
            TenFullPriceOranges,
            FiveHalfPriceApples,
            FiveHalfPriceOranges,
            FiveHalfPriceUnknownFruits,
            NullFruitType,
            NullItemCount,
            DefaultPromoRate,
            EmptyBasketItem,
            NullBasketItem,
        }
        
        public static readonly List<BasketItem> MockBasketItems = new List<BasketItem>() {
            new BasketItem { FruitType = MockApple, ItemCount = 10, PromotionalRate = 1 },
            new BasketItem { FruitType = MockOrange, ItemCount = 10, PromotionalRate = 1 },
            new BasketItem { FruitType = MockApple, ItemCount = 5, PromotionalRate = .50 },
            new BasketItem { FruitType = MockOrange, ItemCount = 5, PromotionalRate = .50 },
            new BasketItem { FruitType = MockUnknownFruit, ItemCount = 5, PromotionalRate = .50 },
            new BasketItem { FruitType = default, ItemCount = 5, PromotionalRate = .50 },
            new BasketItem { FruitType = null, ItemCount = default, PromotionalRate = .50 },
            new BasketItem { FruitType = MockUnknownFruit, ItemCount = 5, PromotionalRate = default },
            new BasketItem(),
            null,
        };
    }
}