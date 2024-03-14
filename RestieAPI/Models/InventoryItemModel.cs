namespace RestieAPI.Models
{
    public class InventoryItemModel
    {
        public string code {get;set; }
        public string item { get; set; }
        public string category { get; set; }
        public int qty { get; set; }
        public int reorderqty { get; set; }
        public float cost { get; set; }
        public float price { get; set; }
        public string status { get; set; }
        public int createdat { get; set; }
        public int updatedat { get; set; }
    }
}
