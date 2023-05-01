using FluentNHibernate.Cfg;
using SmartTimer.Aplicacao.Usuarios.Profiles;
using SmartTimer.Aplicacao.Usuarios.Servicos;
using SmartTimer.Dominio.Usuarios.Servicos;
using SmartTimer.Dominio.Utils.Transacoes;
using SmartTimer.Infra.Usuarios.Mapeamentos;
using SmartTimer.Infra.Usuarios.Repositorios;
using SmartTimer.Infra.Utils.Transacoes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SmartTimer.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            var config = Fluently.Configure().Database(() =>
            {
                return FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard
                .FormatSql()
                .ShowSql()
                .ConnectionString(connectionString);
            })
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
                .CurrentSessionContext("call");

            var sessionFactory = config.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(UsuarioProfile).GetTypeInfo().Assembly);

            services.Scan(scan => scan
                .FromAssemblyOf<UsuariosAppServico>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<UsuariosRepositorio>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<UsuariosServico>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

        }
    }

}

