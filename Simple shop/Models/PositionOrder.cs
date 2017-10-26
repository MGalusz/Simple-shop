namespace Simple_shop.Models
{
    public class PositionOrder
    {
        public int PositionOrderId { get; set; }
        public int OrderId { get; set; }
        public int CourseID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }


        public virtual Course course { get; set; }
        public virtual Orders orders { get; set; }
    }
}