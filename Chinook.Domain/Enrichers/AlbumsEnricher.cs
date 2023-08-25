using Chinook.Domain.ApiModels;
using Chinook.Domain.Helpers;

namespace Chinook.Domain.Enrichers;

public class AlbumsEnricher : ListEnricher<List<AlbumApiModel>>
{
    private readonly AlbumEnricher _enricher;

    public AlbumsEnricher(AlbumEnricher enricher)
    {
        _enricher = enricher;
    }

    public override async Task Process(List<object> representations)
    {
        foreach (var album in representations)
        {
            await _enricher.Process(album as AlbumApiModel);
        }
    }
}