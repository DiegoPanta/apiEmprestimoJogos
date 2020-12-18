using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Usuarios;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ViewModel.Usuarios;
using apiEmprestimoJogos.Results.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace apiEmprestimoJogos.Controllers {
    [Route ("api/token")]
    public class TokenController : EmprestimoJogosBaseController {
        private IServiceProvider _provider;
        private readonly IConfiguration _configuration;

        public TokenController (IConfiguration configuration, IServiceProvider provider) {
            _configuration = configuration;
            _provider = provider;
        }

        [AllowAnonymous]
        [HttpPost, Route ("")]
        public async Task<IActionResult> RequestToken ([FromBody] UsuarioViewModel viewModel) {
            var usuarioGerenciamento = _provider.GetRequiredService<UsuarioGerenciamento> ();

            if (!await usuarioGerenciamento.Autenticar (viewModel.MapTo (new Usuario ()))) {
                return new CredenciaisInvalidaJson ();
            }

            var claims = new [] {
                new Claim (ClaimTypes.Name, viewModel.Codigo)
            };

            var key = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes (_configuration["SecurityKey"])
            );

            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken (
                issuer: "emprestimoJogos.net",
                audience: "emprestimoJogos.net",
                claims : claims,
                expires : DateTime.Now.AddMinutes (30),
                signingCredentials : creds
            );

            return Ok (new {
                token = new JwtSecurityTokenHandler ().WriteToken (token)
            });
        }
    }
}