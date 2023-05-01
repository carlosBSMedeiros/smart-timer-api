using SmartTimer.Dominio.Usuarios.Entidades;
using SmartTimer.Infra.Autenticacoes.Configuracoes;
using SmartTimer.Infra.Autenticacoes.Servicos.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartTimer.Infra.Autenticacoes.Servicos
{
    public class AutenticacoesServico : IAutenticacoesServico
    {
        private readonly AutenticacaoConfiguracao autenticacaoConfiguracao;
        private const string ROLE_TESTE = "free";

        public AutenticacoesServico(AutenticacaoConfiguracao autenticacaoConfiguracao)
        {
            this.autenticacaoConfiguracao = autenticacaoConfiguracao;
        }

        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(autenticacaoConfiguracao.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[] { 
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, ROLE_TESTE)
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
