namespace FruitCalculator.Models
{
    public class BasketItem
    {
        public Fruit FruitType { get; set; }
        
        public int ItemCount { get; set; }
        
        public double PromotionalRate { get; set; }
    }
}