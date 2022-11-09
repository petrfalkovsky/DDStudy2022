namespace Api.Models
{
    public class TokenRequestModel
    {
        public string login { get; set; }
        public string pass { get; set; }
        public TokenRequestModel (string login, string pass)
        {
            this.login = login;
            this.pass = pass;
        }
    }

    public class RefreshTokenRequestModel
    {
        public string RefreshToken { get; set; }

        public RefreshTokenRequestModel(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
