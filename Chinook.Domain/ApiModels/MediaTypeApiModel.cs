using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public partial class MediaTypeApiModel : BaseApiModel, IConvertModel<MediaType>
{
    public string? Name { get; set; }

    public virtual ICollection<TrackApiModel> Tracks { get; set; } = new List<TrackApiModel>();

    public MediaType Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}