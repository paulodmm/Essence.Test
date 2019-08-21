using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Essence.Test.Web.Model;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using Essence.Test.Web.Context;

namespace Essence.Test.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/UserAuth")]
    public class UserAuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public UserAuthController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            return " << Controlador UsuariosController :: WebApiUsuarios >> ";
        }

        [HttpPost("Login")]
        public UserToken Login([FromBody] UserAuth userInfo)
        {
            if (userInfo.Email == "emailteste@essence.com" && userInfo.Password == "senhateste")
            {
                return BuildToken(userInfo);
            }
            else
            {
                throw new Exception("login inválido.");
            }
        }

        private UserToken BuildToken(UserAuth userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("meuValor", "teste da essence"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }


        [AllowAnonymous]
        [HttpPost("Login2")]
        public UserToken Login2(
            [FromBody]UserAuth userInfo,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            if (userInfo.Email == "emailteste@essence.com" && userInfo.Password == "senhateste")
            {
                credenciaisValidas = true;
            }

            if (credenciaisValidas)
            {
                var token = BuildTokenNew(userInfo, signingConfigurations, tokenConfigurations);
                return token;
            }
            else
            {
                throw new Exception("login inválido.");
            }
        }

        private UserToken BuildTokenNew(UserAuth userInfo, SigningConfigurations signingConfigurations,TokenConfigurations tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
               new GenericIdentity(userInfo.Email, "Login"),
               new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email)
               }
           );

            var expiration = DateTime.UtcNow.AddHours(1);
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = expiration;

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            var retorno = new UserToken();
            retorno.Expiration = dataExpiracao;
            retorno.Token = token;

            return retorno;
            //return new
            //{
            //    authenticated = true,
            //    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
            //    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
            //    accessToken = token,
            //    message = "OK"
            //};
        }
    }
}