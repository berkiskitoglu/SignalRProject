using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class MenuTableViewModel
    {
        public int MenuTableID { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool Status { get; set; }
    }
}