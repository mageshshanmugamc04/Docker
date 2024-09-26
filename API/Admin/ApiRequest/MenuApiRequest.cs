using System.ComponentModel.DataAnnotations;

namespace Admin.ApiRequest
{
    public class MenuApiRequest
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Url { get; set; }
        [Required]
        public required string Icon { get; set; }
        [Required]
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}