using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CreateUserModel
    {
        [Required]
        public string Name { get; set; } = "empty";
        [Required]
        public string Email { get; set; } = "empty";
        [Required]
        public string Password { get; set; } = "empty";
        [Required]
        [Compare(nameof(Password))]
        public string RetryPassword { get; set; } = "empty";
        [Required]
        public DateTimeOffset BirthDate { get; set; }

        public CreateUserModel(string name, string email, string password, string retryPassword, DateTimeOffset birthDate)
        {
            Name = name;
            Email = email;
            Password = password;
            RetryPassword = retryPassword;
            BirthDate = birthDate;
        }
    }
}
