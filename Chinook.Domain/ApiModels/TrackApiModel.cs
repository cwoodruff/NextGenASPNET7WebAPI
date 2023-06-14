namespace Chinook.Domain.ApiModels;

public partial class TrackApiModel : BaseApiModel
{
    public string Name { get; set; } = null!;

    public int? AlbumId { get; set; }

    public int MediaTypeId { get; set; }

    public int? GenreId { get; set; }

    public string? Composer { get; set; }

    public int Milliseconds { get; set; }

    public int? Bytes { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual AlbumApiModel? Album { get; set; }

    public virtual GenreApiModel? Genre { get; set; }

    public virtual ICollection<InvoiceLineApiModel> InvoiceLines { get; set; } = new List<InvoiceLineApiModel>();

    public virtual MediaTypeApiModel MediaType { get; set; } = null!;

    public virtual ICollection<PlaylistApiModel> Playlists { get; set; } = new List<PlaylistApiModel>();
}
