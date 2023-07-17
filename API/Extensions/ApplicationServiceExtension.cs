using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace API.Extensions;
//Configurar las politicas cors
public static class ApplicationServiceExtension{
    public static void ConfigureCors(this IServiceCollection service)=>service.AddCors(
        option=>{
            option.AddPolicy(
                name:"CorsPolicy",
                builder=>builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        }
    );

    public static void AddApplicationServices(this IServiceCollection services){
        services.AddScoped<IUnitOfWork,UnitOfWork>();
    }
    
}