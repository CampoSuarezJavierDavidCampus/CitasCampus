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
    
}