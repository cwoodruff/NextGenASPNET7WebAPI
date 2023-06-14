namespace Chinook.Domain.ApiModels;

public partial class AlbumApiModel : BaseApiModel
{
    public string Title { get; set; } = null!;

    public int ArtistId { get; set; }

    public virtual ArtistApiModel Artist { get; set; } = null!;

    public virtual ICollection<TrackApiModel> Tracks { get; set; } = new List<TrackApiModel>();
}
