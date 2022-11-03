namespace Api.Models
{
    public class TokenRequestModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public TokenRequestModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
