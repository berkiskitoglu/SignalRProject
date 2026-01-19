namespace SignalRWebUI.ViewModels.CategoryViewModel
{
    public class UpdateCategoryViewModel
    {
        public int CategoryID { get; set; }  
        public required string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
