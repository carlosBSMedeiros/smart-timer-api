using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartTimer.Infra.Autenticacoes.Configuracoes;
using SmartTimer.Infra.Autenticacoes.Servicos;
using SmartTimer.Infra.Autenticacoes.Servicos.Interfaces;
using SmartTimer.IoC;
using SmartTimer.IoC.Filtros;
using System.Text;

namespace SmartTimer.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MySQL");
            var tokenConfiguration = Configuration.GetSection("TokenConfigurations");

            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(RegraDeNegocioExcecaoFilter));
            });

            var key = Encoding.ASCII.GetBytes(tokenConfiguration["Key"]);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });


            services.Configure<AutenticacaoConfiguracao>(tokenConfiguration);
            services.AddSingleton<AutenticacaoConfiguracao>(sp => sp.GetRequiredService<IOptionsMonitor<AutenticacaoConfiguracao>>().CurrentValue);
            services.AddScoped<IAutenticacoesServico, AutenticacoesServico>();

            NativeInjector.RegisterServices(services, connectionString);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}

