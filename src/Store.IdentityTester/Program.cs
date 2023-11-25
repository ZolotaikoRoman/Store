using IdentityModel.Client;

var httpClient = new HttpClient();

var response = await httpClient.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
{
    Address = "https://localhost:5001",
    GrantType = "authorization_code",

    ClientId = "ui",
    ClientSecret = "secret",
});

Console.ReadKey();