using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Supabase.TutorialOne.Models
{
    [Table("artists")]
    public class ArtistManagement : BaseModel
    { 
        [PrimaryKey("id",false)] // this is auto-generated
        public long Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;
        
        [Column("stage_name")]
        public string? StageName { get; set; }

        [Column("genre")]
        public string? Genre { get; set; }

        [Column("bio")]
        public string? Bio { get; set; }

        [Column("songs_released")]
        public int? SongsReleased { get; set; }

        [Column("is_active")]
        public bool? IsActive { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

    }
}
