using Chinook.Domain.ApiModels;
using Chinook.Domain.Extensions;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public async Task<PagedList<GenreApiModel>> GetAllGenre(int pageNumber, int pageSize)
    {
        var genres = await _genreRepository!.GetAll(pageNumber, pageSize);
        var genreApiModels = genres.ConvertAll().ToList();

        foreach (var genre in genreApiModels)
        {
            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800))
                    .AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(604800);

            _cache!.Set(string.Concat("Genre-", genre.Id), genre, (TimeSpan)cacheEntryOptions);
        }

        var newPagedList =
            new PagedList<GenreApiModel>(genreApiModels, genres.TotalCount, genres.CurrentPage, genres.PageSize);
        return newPagedList;
    }

    public async Task<GenreApiModel?> GetGenreById(int? id)
    {
        var genreApiModelCached = _cache!.Get<GenreApiModel>(string.Concat("Genre-", id));

        if (genreApiModelCached != null)
        {
            return genreApiModelCached;
        }
        else
        {
            var genre = await _genreRepository!.GetById(id);
            if (genre == null) return null;
            var genreApiModel = genre.Convert();
            //genreApiModel.Tracks = (await GetTrackByGenreId(genreApiModel.Id)).ToList();

            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800))
                    .AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(604800);

            _cache!.Set(string.Concat("Genre-", genreApiModel.Id), genreApiModel, (TimeSpan)cacheEntryOptions);

            return genreApiModel;
        }
    }

    public async Task<GenreApiModel> AddGenre(GenreApiModel newGenreApiModel)
    {
        await _genreValidator.ValidateAndThrowAsync(newGenreApiModel);

        var genre = newGenreApiModel.Convert();

        genre = await _genreRepository!.Add(genre);
        newGenreApiModel.Id = genre.Id;
        return newGenreApiModel;
    }

    public async Task<bool> UpdateGenre(GenreApiModel genreApiModel)
    {
        await _genreValidator.ValidateAndThrowAsync(genreApiModel);

        var genre = await _genreRepository!.GetById(genreApiModel.Id);

        if (genre == null) return false;
        genre.Id = genreApiModel.Id;
        genre.Name = genreApiModel.Name ?? string.Empty;

        return await _genreRepository.Update(genre);
    }

    public Task<bool> DeleteGenre(int id)
        => _genreRepository!.Delete(id);
}