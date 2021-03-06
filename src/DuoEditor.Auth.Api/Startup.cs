
using DuoEditor.Auth.App.Config;
using DuoEditor.Auth.Api.Config;
using DuoEditor.Auth.Infra.Persistence;
using DuoEditor.Auth.Jwt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Redis;
using DuoEditor.Auth.Service.Config;
using DuoEditor.Auth.Service.Clients;

namespace DuoEditor.Auth.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApiDbContext>(options =>
      {
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddSingleton<IRedisClientsManagerAsync>(c => new RedisManagerPool(Configuration.GetConnectionString("RedisConnection")));
      services.AddControllers();

      // Configurations
      services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
      services.Configure<ImageClientConfig>(Configuration.GetSection("Services:Image"));

      // Clients
      services.AddHttpClient<ImageHttpClient>();

      // Internal Dependencies
      services.AddApplication();
      services.AddDependencies();

      // Auth
      services.AddAuthentication("Jwt").AddScheme<JwtAuthenticationOptions, JwtAuthenticationHandler>("Jwt", opt => { });

      services.AddAutoMapper(typeof(Startup));
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new() { Title = "DuoEditor.Auth.Api", Version = "v1" });
      });
      services.AddSwaggerGenNewtonsoftSupport();

      var assembly = AppDomain.CurrentDomain.Load("DuoEditor.Auth.App");
      services.AddMediatR(assembly);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DuoEditor.Auth.Api v1"));
      }

      // app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}