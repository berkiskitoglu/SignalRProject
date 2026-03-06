using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class AboutViewModel
    {
        public int AboutID { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}