using System.Collections.Generic;
using System.Linq;
using FruitCalculator;
using FruitCalculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static FruitCalculatorUnitTests.MockData.MockBasketItemIndex;

namespace FruitCalculatorUnitTests
{
    [TestClass]
    public class FruitCalculatorTests
    {
        private Mock<ILogger> _mockLogger;

        [TestInitialize]
        public void Before()
        {
            _mockLogger = new Mock<ILogger>();
        }

        [DataTestMethod]
        [DataRow(TenFullPriceApples, 50)] 
        [DataRow(TenFullPriceOranges, 100)]
        [DataRow(FiveHalfPriceApples, 12.5)]
        [DataRow(FiveHalfPriceOranges, 25)]
        [DataRow(FiveHalfPriceUnknownFruits, 5)]
        [DataRow(NullFruitType, 0)]
        [DataRow(NullItemCount, 0)]
        [DataRow(DefaultPromoRate, 10)]
        [DataRow(EmptyBasketItem, 0)]
        [DataRow(NullBasketItem, 0)]
        public void ShouldCalculateBasketItemPrice(int basketItemIndex, double expectedCost)
        {
            var basketItem = MockData.MockBasketItems[basketItemIndex];

            var actualCost = basketItem.CalculateBasketItemPrice(_mockLogger.Object);
            Assert.AreEqual(expectedCost, actualCost);

            var expectedLog =
                $"Purchase of {basketItem?.ItemCount ?? 0} {basketItem?.FruitType?.Name ?? "unknown item"}s cost a total of {expectedCost}";
            _mockLogger.Verify(mockLog => mockLog.Log(expectedLog), Times.Once);
        }

        [DataRow(TenFullPriceApples, TenFullPriceApples, TenFullPriceApples, 150)] 
        [DataRow(TenFullPriceOranges, TenFullPriceOranges, TenFullPriceOranges, 300)] 
        [DataRow(TenFullPriceOranges, TenFullPriceOranges, FiveHalfPriceUnknownFruits, 205)] 
        [DataRow(TenFullPriceApples, NullBasketItem, DefaultPromoRate, 60)] 
        [DataTestMethod]
        public void ShouldCalculateBasketPrice(int firstItemIndex, int secondItemIndex, int thirdItemIndex, double actualPrice)
        {
            var basket = new Basket
            {
                BasketItems = new List<BasketItem>
                {
                    MockData.MockBasketItems[firstItemIndex], 
                    MockData.MockBasketItems[secondItemIndex], 
                    MockData.MockBasketItems[thirdItemIndex]
                },
            };

            var expectedCost = basket.CalculateBasketPrice(_mockLogger.Object);
            Assert.AreEqual(expectedCost, actualPrice);

            var expectedLogCount = basket.BasketItems.Any(item => item == null) ? 2 : 3;
            _mockLogger.Verify(mockLog => mockLog.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
        }
        
        [TestMethod]
        public void ShouldCalculateNullBasketPrice()
        {
            var basketItem = new Basket();

            var actualCost = basketItem.CalculateBasketPrice(_mockLogger.Object);
            Assert.AreEqual(0, actualCost);
            
            _mockLogger.Verify(mockLog => mockLog.Log("Warning - the basket is empty."), Times.Once);
        }
    }
}