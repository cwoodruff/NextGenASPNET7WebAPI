namespace Chinook.Domain.ApiModels;

public partial class ArtistApiModel : BaseApiModel
{
    public string? Name { get; set; }

    public virtual ICollection<AlbumApiModel> Albums { get; set; } = new List<AlbumApiModel>();
}
