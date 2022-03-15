using System.Security.Claims;
using System.Text.Json;
using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace GettyX.Web.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localstorage;
        private readonly HttpClient _http;


        public CustomAuthenticationStateProvider(ILocalStorageService localstorage,
                                                HttpClient http)
        {
            _localstorage = localstorage;
            _http = http;

        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var token = await _localstorage.GetItemAsStringAsync("0115");
            var identity = new ClaimsIdentity();
            
            _http.DefaultRequestHeaders.Authorization = null;


            if (!string.IsNullOrEmpty(token))
            {

                //Check if token expired
                var tokenExpired = false;
                var ClaimIdentity = ParseClaimsFromJwt(token);
                var ExpDateUnix = ClaimIdentity.First(x => x.Type == "exp").Value;
                var ExpInSec = Convert.ToInt32(ExpDateUnix);

                //The expiration date in the token it's in Unix timestamp
                var expirationDateFromUnix = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds(ExpInSec)
                            .ToUniversalTime();


                var nowdate = DateTime.UtcNow;

                //comparing dates
                if (expirationDateFromUnix <= nowdate)
                {
                    tokenExpired = true;
                }


                if (!tokenExpired)
                {


                    identity = new ClaimsIdentity(ClaimIdentity, "jwt");
                    _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));

                }
                else
                {

                    await _localstorage.RemoveItemAsync("token");
                }

                
            }


            var user = new ClaimsPrincipal(identity);

            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;

        }
       
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];

            var jsonBytes = ParseBase64WithoutPadding(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            

            ExtractRolesFromJWT(claims, keyValuePairs);

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }

        private static void ExtractRolesFromJWT(List<Claim> claims, Dictionary<string, object> keyValuePairs)
        {
            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
            if (roles != null)
            {
                var parsedRoles = roles.ToString().Trim().TrimStart('[').TrimEnd(']').Split(',');
                if (parsedRoles.Length > 1)
                {
                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole.Trim('"')));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, parsedRoles[0]));
                }
                keyValuePairs.Remove(ClaimTypes.Role);
            }
        }


        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
