namespace Supabase.TutorialOne.Extensions
{
    public static class OpenApiConfig
    {

        public static void AddOpenApiService(this IServiceCollection services) 
        {
            services.AddOpenApi();
        }

        public static void UseOpenApiService(this WebApplication app) 
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
        }
    }
}
