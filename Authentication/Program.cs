using Authentication.Data.Context;
using Authentication.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Authenticatio 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Services
            // Add services to the container.

            #region Database
            builder.Services.AddDbContext<EmployeeContext>(Options=>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDB"));
            });

            #endregion
            #region AspIdentity

            builder.Services.AddIdentity<Employee, IdentityRole>(Options =>
            {
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = false;
                Options.Password.RequireDigit = false;
                Options.Password.RequiredLength = 6;
                Options.User.RequireUniqueEmail = true;
                Options.Lockout.MaxFailedAccessAttempts = 5;
                Options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromSeconds(30);
            })
                .AddEntityFrameworkStores<EmployeeContext>();
            #endregion
            #region Authentication
            builder.Services.AddAuthentication(options=>//add this overload to override the authetication confi 
            {                                           //of the identity
                options.DefaultAuthenticateScheme = "Authentication Schema3";
                options.DefaultChallengeScheme = "Authentication Schema3";//means
                //if the user is not authorized send 401 unauthorized not 404 
            })
                .AddJwtBearer("Authentication Schema1", Options => { })
                .AddJwtBearer("Authentication Schema2", Options => { })
                .AddJwtBearer("Authentication Schema3", Options =>
                {
                    var KeyFromConfig = builder.Configuration.GetValue<string>("SecretKey");//get the value from Json file

                    var KeyInBytes = Encoding.ASCII.GetBytes(KeyFromConfig);
                    var SecretKey = new SymmetricSecurityKey(KeyInBytes);
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = SecretKey, //providing Secret KEy to the application to be able to validate the Token
                        ValidateIssuer=false,
                        ValidateAudience=false, 
                    };
                });

            #endregion
            #region Authorization
            builder.Services.AddAuthorization(options=>
            {
                options.AddPolicy("ManagerOnly", policy=> policy
                .RequireClaim(ClaimTypes.Role,"Manager","CEO")
                .RequireClaim(ClaimTypes.NameIdentifier)
                
                );
            
            });
            #endregion
            #region Default
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #endregion
            var app = builder.Build();


            #region MiddleWares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();//added to validate the Token
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}