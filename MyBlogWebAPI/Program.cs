
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Repository;
using MyBlog.Repository.DbContexts;
using MyBlog.Service;
using MyBlogWebAPI.Util._AutoMapper;
using System.Text;

namespace MyBlogWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMemoryCache();
            builder.Services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
                option.InstanceName = "wyc";

            });
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference=new OpenApiReference
              {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
              }
            },
            new string[] {}
          }
        });
            }
);
            //Add
            
            builder.Services.AddDbContext<BlogDbContext>(o=>
            o.UseSqlServer(builder.Configuration.GetConnectionString("BloggingDatabase")));
            builder.Services.AddCustomIOC();
            builder.Services.AddCustomJWT();
            builder.Services.AddAutoMapper(typeof(CustomAutoMapperProfile));
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IBlogNewsRepository, BlogNewsRepository>();
            services.AddScoped<IBlogNewService, BlogNewService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ITypeIdRepository, TypeIdRepository>();
            services.AddScoped<ITypeIdService, TypeIdService>();

            return services;
        }
        public static IServiceCollection AddCustomJWT(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF")),
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:6060",
                    ValidateAudience = true,
                    ValidAudience = "http://localhost:5000",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(60)
                };
            });
            return services;
        }
    }
}