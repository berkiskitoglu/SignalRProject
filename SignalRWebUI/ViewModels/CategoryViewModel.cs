using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}