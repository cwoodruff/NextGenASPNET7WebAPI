using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;

namespace Chinook.Domain.Entities;

public partial class MediaType : BaseEntity, IConvertModel<MediaTypeApiModel>
{
    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public MediaTypeApiModel Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}