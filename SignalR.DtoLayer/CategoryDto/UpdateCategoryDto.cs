namespace SignalR.DtoLayer.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }
        public required string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
