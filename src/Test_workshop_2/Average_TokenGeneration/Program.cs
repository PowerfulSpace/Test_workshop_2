

// Секретный ключ для подписи токена
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



string secretKey = "ThisIsAReallyStrongSecretKey1234"; // Замените на свой ключ




Console.WriteLine("JWT Token Generator");

// Генерация токена
var token = GenerateJwtToken("123", "user@example.com");
Console.WriteLine($"Generated Token: {token}");

// Проверка токена
Console.WriteLine("Validating token...");
var isValid = ValidateJwtToken(token);
Console.WriteLine($"Token is valid: {isValid}");

Console.ReadLine();



// Метод генерации JWT токена
string GenerateJwtToken(string userId, string email)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(secretKey);

    // Задание параметров токена (заголовок и полезная нагрузка)
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new Claim[]
        {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Email, email)
        }),
        Expires = DateTime.UtcNow.AddHours(1), // Время жизни токена
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    // Создание токена
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}

// Метод проверки валидности JWT токена
bool ValidateJwtToken(string token)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(secretKey);

    try
    {
        // Валидация токена
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        return true; // Токен валиден
    }
    catch
    {
        return false; // Токен не валиден
    }
}

