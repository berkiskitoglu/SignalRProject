namespace SignalR.DtoLayer.FeatureDto
{
    public class UpdateFeatureDto
    {
        public int FeatureID { get; set; }
        public required string Title1 { get; set; }
        public required string Description1 { get; set; } 
        public required string Title2 { get; set; } 
        public required string Description2 { get; set; } 
        public required string Title3 { get; set; }
        public required string Description3 { get; set; } 
    }
}
