namespace SignalR.DtoLayer.CategoryDtos
{
    public class GetCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool Status { get; set; }
    }
}
