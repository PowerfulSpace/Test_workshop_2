
// Секретный ключ для подписи JWT
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var secretKey = "ThisIsAReallyStrongSecretKey1234"; // Замените на ваш собственный ключ

// Создание симметричного ключа
var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

// Определяем параметры токена: субъекта, время жизни и claims
var tokenDescriptor = new SecurityTokenDescriptor
{
    Subject = new ClaimsIdentity(new[]
    {
                new Claim(JwtRegisteredClaimNames.Sub, "user123"),
                new Claim(JwtRegisteredClaimNames.Email, "user@example.com"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // уникальный идентификатор токена
            }),
    Expires = DateTime.Now.AddMinutes(30), // Время жизни токена
    SigningCredentials = credentials
};

// Генерация токена
var tokenHandler = new JwtSecurityTokenHandler();
var token = tokenHandler.CreateToken(tokenDescriptor);
var jwtToken = tokenHandler.WriteToken(token);

// Вывод токена в консоль
Console.WriteLine("Generated JWT Token: ");
Console.WriteLine(jwtToken);

Console.ReadLine();