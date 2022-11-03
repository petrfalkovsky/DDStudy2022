namespace Api.Models
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public TokenModel(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
