namespace RestWithAsp_NETUdemy.Security.Configuration
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issue { get; set; }
        public double Seconds { get; set; }
    }
}
