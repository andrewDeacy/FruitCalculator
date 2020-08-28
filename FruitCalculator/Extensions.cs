using System;
using System.Linq;
using FruitCalculator.Models;

namespace FruitCalculator
{
    public static class Extensions
    {
        public static double CalculateBasketPrice(this Basket basket, ILogger logger)
        {
            var basketPrice = 0.0;

            if (basket?.BasketItems == null || !basket.BasketItems.Any())
            {
                logger.Log("Warning - the basket is empty.");
                return basketPrice;
            }
            
            basket.BasketItems?.ForEach(item => basketPrice += item?.CalculateBasketItemPrice(logger) ?? 0);
            return basketPrice;
        }

        public static double CalculateBasketItemPrice(this BasketItem basketItem, ILogger logger)
        {
            var price =  basketItem?.FruitType?.Price ?? 0;
            var count = basketItem?.ItemCount ?? 0;
            var promoRate = basketItem?.PromotionalRate <= 0 ? 1.0 : basketItem?.PromotionalRate ?? 1.0;

            var basketItemPrice =  price * count * promoRate;
            logger.Log(
                $"Purchase of {count} {basketItem?.FruitType?.Name ?? "unknown item"}s cost a total of {basketItemPrice}");
            
            return basketItemPrice;
        }
    }
}