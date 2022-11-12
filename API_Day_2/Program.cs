using Hospital.BL;
using Hospital.DAL;
using Microsoft.EntityFrameworkCore;

namespace API_Day_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
             #region service
            #region default
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Database
            var connectionString =builder.Configuration.GetConnectionString("Hospital") ;
            builder.Services.AddDbContext<HospitalDb>(options => options.UseSqlServer(connectionString));


            #endregion

            #region Repos
            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<IPatientRepo,PatientRepo >();
            #endregion

            #region Automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            #endregion


            #region Manager

            builder.Services.AddScoped<IDoctorManager, DoctorManager>();
            builder.Services.AddScoped<IPatientManager,PatientManager>();
            #endregion
            #endregion
            var app = builder.Build();

            #region middleware
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}