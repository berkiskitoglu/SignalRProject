namespace SignalR.DtoLayer.CategoryDto
{
    public class GetCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool Status { get; set; }
    }
}
