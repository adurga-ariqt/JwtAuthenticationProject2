using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationProject2
{
    public class JwtAuthentication
    {
          public void MyMethod()
          {
            // The secret key
            var secretKey = "the secret key for  Durga Authentication";
            // The header and payload
            var header = new JwtHeader(new SigningCredentials(
              new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
              SecurityAlgorithms.HmacSha256));

            Console.WriteLine("Enter User Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Email");
            var email = Console.ReadLine();

            var issuer = "Facebook";
           
            var audience ="instagram";


            var claims = new List<Claim>();
            claims.Add(new Claim("Name", $"{name}"));
            claims.Add(new Claim("Email", $"{email}"));

           
           
            var startTime = DateTime.Now;
            var endTime = DateTime.Now.AddMinutes(10);


            var payload = new JwtPayload(issuer, audience, claims, startTime, endTime);


            // Create the JWT
            var jwt = new JwtSecurityToken(header, payload);

            // Encode the JWT as a string
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            Console.WriteLine("Generated token is : \n " + encodedJwt);

          }
    }
    
}
