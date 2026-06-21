using Domain.ValueObjects;

namespace Application.DTO
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Role { get; set; }
    }
}
