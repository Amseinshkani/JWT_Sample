using Core.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Token
{
    public class JWTAuthorizationManager
    {
        public JWTFeilds Authenticate(string UserName, string Password) 
        {
            if (UserName != "AmirHosein" || Password != "123")
            {
                return null;
            }
            var TokenExpireTimeStamp = DateTime.Now.AddHours(Constansts.JWT_TOKEN_EXPIRE_TIME);

            var JWTSecuretyTokenHandler = new JwtSecurityTokenHandler();

            var TokenKey = Encoding.ASCII.GetBytes(Constansts.JWT_SECURITY_KEY_FOR_TOKEN);

            var SecurityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("UserName", UserName),
                    new Claim(ClaimTypes.PrimaryGroupSid,"User Group 01")
                }),
                Expires= TokenExpireTimeStamp,

                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(TokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = JWTSecuretyTokenHandler
                .CreateToken(SecurityTokenDescriptor);

            var Token = JWTSecuretyTokenHandler
                .WriteToken(securityToken);

            return new JWTFeilds 
            {
            Token= Token,
            UserName= UserName,
            ExpireTime = (int)TokenExpireTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };



        }
    }
}
