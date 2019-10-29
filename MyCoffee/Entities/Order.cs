namespace MyCoffee.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        private float TotalPrice { get; }

        public void calculateTotalPrice()
        {
            TotalPrice = 0.0;
        }
    }
}