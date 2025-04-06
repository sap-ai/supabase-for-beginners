using Supabase.TutorialOne.Endpoints;
using Supabase.TutorialOne.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApiService();

app.UseHttpsRedirection();

app.AddArtistEndpoints();

app.Run();

