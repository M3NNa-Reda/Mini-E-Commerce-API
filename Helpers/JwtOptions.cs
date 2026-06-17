namespace Mini_E_Commerce_API.Helpers
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Lifetime { get; set; }
        public string Signingkey { get; set; }
    }

}
