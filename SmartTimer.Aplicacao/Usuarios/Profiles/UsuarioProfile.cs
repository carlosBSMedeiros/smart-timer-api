using AutoMapper;
using SmartTimer.Dominio.Usuarios.Entidades;
using SmartTimer.DataTransfer.Usuarios.Response;

namespace SmartTimer.Aplicacao.Usuarios.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}
