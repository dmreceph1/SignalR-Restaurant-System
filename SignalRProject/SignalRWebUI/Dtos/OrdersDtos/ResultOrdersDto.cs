namespace SignalRWebUI.Dtos.OrdersDtos
{
    public class ResultOrdersDto
    {
        public int OrdersID { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
