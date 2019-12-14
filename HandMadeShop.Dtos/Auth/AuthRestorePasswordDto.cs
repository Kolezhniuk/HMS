namespace HandMadeShop.Dtos.Auth
{
    public class AuthRestorePasswordDto
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string PasswordRestoreCode { get; set; }
    }
}