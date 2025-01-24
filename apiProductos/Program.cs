
using apiProductos.Data;
using apiProductos.Services;
using apiProducts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace apiProductos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Swagger Documentation Section
            var info = new OpenApiInfo()
            {
                Title = "API de Productos",
                Version = "v1",
                Description = "Provee de backend de datos de productos",
                Contact = new OpenApiContact()
                {
                    Name = "Roberto Corona",
                    Email = "roco170@gmail.com",
                }

            };


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.

            builder.Services.AddControllers();
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);
                c.EnableAnnotations();

            });


            builder.Services.AddScoped<IProductoService, ProductoService>();

            //add support for CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });


            var app = builder.Build();

            app.UseCors("AllowAll");

            // Robert - 250109: Ensure that the DB was created
            app.InitializeDatabase();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
