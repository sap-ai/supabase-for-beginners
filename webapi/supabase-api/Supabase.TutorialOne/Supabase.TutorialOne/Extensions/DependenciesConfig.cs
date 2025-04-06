namespace Supabase.TutorialOne.Extensions
{
    public static class DependenciesConfig
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApiService();

            var supabaseUrl = builder.Configuration["Supabase:Url"];
            var supabaseKey = builder.Configuration["Supabase:Key"];
            builder.Services.AddSupabaseService(supabaseUrl, supabaseKey);
        }
    }
}
