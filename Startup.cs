using System.Text;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ValidationServiceModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace apiEmprestimoJogos {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            
            services.AddDbContext<ApiDbContext> (options =>
                options.UseSqlServer ("Server=.\\SQLEXPRESS;Database=DbEmprestimoJogos;Integrated Security=True"));

            //ServiceModel
            services.AddTransient<ClienteGerenciamento>();
            services.AddTransient<EmprestimoGerenciamento>();
            services.AddTransient<GeneroGerenciamento>();
            services.AddTransient<JogoGerenciamento>();
            services.AddTransient<TipoGerenciamento>();
            services.AddTransient<UsuarioGerenciamento>();
            services.AddTransient<MidiaGerenciamento>();

            //ValidationServiceModel
            services.AddTransient<ClienteValidation>();
            services.AddTransient<EmprestimoValidation>();
            services.AddTransient<GeneroValidation>();
            services.AddTransient<JogoValidation>();
            services.AddTransient<TipoValidation>();
            services.AddTransient<UsuarioValidation>();
            services.AddTransient<MidiaValidation>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "emprestimoJogos.net",
                    ValidAudience = "emprestimoJogos.net",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["SecurityKey"])
                    )
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddCors();
            services.AddControllers ();
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseRouting ();

             // global cors policy
            app.UseCors(policy => policy
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}