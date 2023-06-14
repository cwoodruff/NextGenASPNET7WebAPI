namespace Chinook.Domain.ApiModels;

public partial class MediaTypeApiModel : BaseApiModel
{
    public string? Name { get; set; }

    public virtual ICollection<TrackApiModel> Tracks { get; set; } = new List<TrackApiModel>();
}
