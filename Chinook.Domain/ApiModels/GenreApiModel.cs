namespace Chinook.Domain.ApiModels;

public partial class GenreApiModel : BaseApiModel
{
    public string? Name { get; set; }

    public virtual ICollection<TrackApiModel> Tracks { get; set; } = new List<TrackApiModel>();
}
