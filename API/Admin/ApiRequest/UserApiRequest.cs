using System.ComponentModel.DataAnnotations;

namespace Admin.ApiRequest
{
    public class UserApiRequest
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}