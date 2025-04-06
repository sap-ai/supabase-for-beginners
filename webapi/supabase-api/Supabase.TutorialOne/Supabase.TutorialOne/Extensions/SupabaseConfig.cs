namespace Supabase.TutorialOne.Extensions
{
    public static class SupabaseConfig
    {
        public static void AddSupabaseService(this IServiceCollection services, string url, string key)
        {
            services.AddScoped<Client>(provider =>
            {
                var options = new SupabaseOptions
                {
                    AutoRefreshToken = true,
                    AutoConnectRealtime = true
                };
                var supabaseClient = new Client(url, key, options);
                supabaseClient.InitializeAsync().Wait(); 
                return supabaseClient;
            });

        }
    }
}
