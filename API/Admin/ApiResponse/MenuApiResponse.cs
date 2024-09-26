namespace Admin.ApiResponse
{
    public class MenuApiReponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Url { get; set; }
        public required string Icon { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}