namespace MSBProCrudApp.Infrasturcture;

public class Configuration
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public JWTOptions JWTOptions { get; set; }
}

public class ConnectionStrings
{
    public string DefaultConnectionString { get; set; }
}

public class JWTOptions
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiresMinutes { get; set; }
}