using NetworkSpeedAPI.Services;

namespace NetworkSpeedAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add the memory cache & response compression services.
            builder.Services.AddMemoryCache();
            builder.Services.AddResponseCompression();

            builder.Services.AddScoped<INetworkSpeedService, NetworkSpeedService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "NordCloud Tech assignment - Network speed",
                    Version = "v1.0"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            // Configure Cors (And Middleware)
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());

            app.UseSwagger();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
            }
            app.UseResponseCompression();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}