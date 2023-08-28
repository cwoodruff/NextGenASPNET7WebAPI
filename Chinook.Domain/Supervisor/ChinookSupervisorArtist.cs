using Chinook.Domain.ApiModels;
using Chinook.Domain.Extensions;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public async Task<PagedList<ArtistApiModel>> GetAllArtist(int pageNumber, int pageSize)
    {
        var artists = await _artistRepository!.GetAll(pageNumber, pageSize);
        var artistApiModels = artists.ConvertAll().ToList();

        foreach (var artist in artistApiModels)
        {
            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800))
                    .AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(604800);

            _cache!.Set(string.Concat("Artist-", artist.Id), artist, (TimeSpan)cacheEntryOptions);
        }

        var newPagedList =
            new PagedList<ArtistApiModel>(artistApiModels, artists.TotalCount, artists.CurrentPage, artists.PageSize);
        return newPagedList;
    }

    public async Task<ArtistApiModel> GetArtistById(int id)
    {
        var artistApiModelCached = _cache!.Get<ArtistApiModel>(string.Concat("Artist-", id));

        if (artistApiModelCached != null)
        {
            return artistApiModelCached;
        }
        else
        {
            var artist = await _artistRepository!.GetById(id);
            if (artist == null) return null!;
            var artistApiModel = artist.Convert();
            //artistApiModel.Albums = (await _albumRepository.GetByArtistId(artist.Id)).ConvertAll().ToList();

            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800))
                    .AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(604800);

            _cache!.Set(string.Concat("Artist-", artistApiModel.Id), artistApiModel, (TimeSpan)cacheEntryOptions);

            return artistApiModel;
        }
    }

    public async Task<ArtistApiModel> AddArtist(ArtistApiModel newArtistApiModel)
    {
        await _artistValidator.ValidateAndThrowAsync(newArtistApiModel);

        var artist = newArtistApiModel.Convert();

        artist = await _artistRepository!.Add(artist);
        newArtistApiModel.Id = artist.Id;
        return newArtistApiModel;
    }

    public async Task<bool> UpdateArtist(ArtistApiModel artistApiModel)
    {
        await _artistValidator.ValidateAndThrowAsync(artistApiModel);

        var artist = await _artistRepository!.GetById(artistApiModel.Id);

        if (artist == null) return false;
        artist.Id = artistApiModel.Id;
        artist.Name = artistApiModel.Name ?? string.Empty;

        return await _artistRepository.Update(artist);
    }

    public Task<bool> DeleteArtist(int id)
        => _artistRepository!.Delete(id);
}