using Supabase.TutorialOne.Models;

namespace Supabase.TutorialOne.Endpoints
{
    public static class ArtistEndpoint
    {
        public static void AddArtistEndpoints(this WebApplication app) 
        {
            app.MapPost("/artists", async (CreateArtistRequest request, Supabase.Client client) =>
            {
                var artist = new ArtistManagement
                {
                    FullName = request.FullName,
                    StageName = request.StageName,
                    Genre = request.Genre,
                    Bio = request.Bio,
                    SongsReleased = request.SongsReleased,
                    IsActive = request.IsActive,
                    CreatedAt = DateTime.UtcNow
                };
                var response = await client.From<ArtistManagement>().Insert(artist);
                var newArtist = response.Models.First();
                return Results.Ok(newArtist.Id);
            });

            app.MapGet("/artists/{id}", async (long id,Supabase.Client client) =>
            {
                // this is our body, supabase supports LINQ queries
                var response = await client
                .From<ArtistManagement>()
                .Where(n => n.Id == id)
                .Get();

                var artists = response.Models.FirstOrDefault();

                if (artists is null)
                {
                    return Results.NotFound();
                }
                var artistResponse = new ArtistRequestResponse
                {
                    Id = artists.Id,
                    FullName = artists.FullName,
                    StageName = artists.StageName,
                    Genre = artists.Genre,
                    Bio = artists.Bio,
                    SongsReleased = artists.SongsReleased,
                    IsActive = artists.IsActive,
                    CreatedAt = artists.CreatedAt
                };

                return Results.Ok(artistResponse);
            });

            app.MapDelete("/artists/{id}", async (long id, Supabase.Client client) =>
            {
                await client
                .From<ArtistManagement>()
                .Where(n => n.Id == id)
                .Delete();

                return Results.Ok();
            });
        }


        // Classes to map the request and response for Artists
        public class CreateArtistRequest
        {

            public string FullName { get; set; } = string.Empty;
            public string? StageName { get; set; }
            public string? Genre { get; set; }
            public string? Bio { get; set; }
            public int? SongsReleased { get; set; }
            public bool? IsActive { get; set; }

        }

        public class ArtistRequestResponse
        {
            public long Id { get; set; }
            public string FullName { get; set; } = string.Empty;
            public string? StageName { get; set; }
            public string? Genre { get; set; }
            public string? Bio { get; set; }
            public int? SongsReleased { get; set; }
            public bool? IsActive { get; set; }
            public DateTime? CreatedAt { get; set; }

        }

    }
}
