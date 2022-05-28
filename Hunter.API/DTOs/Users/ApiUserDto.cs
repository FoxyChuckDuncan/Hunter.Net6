using System.ComponentModel.DataAnnotations;

namespace Hunter.API.DTOs.Users
{
    public class ApiUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string KnownAs { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
