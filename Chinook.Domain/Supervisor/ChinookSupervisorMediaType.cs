using Chinook.Domain.ApiModels;
using Chinook.Domain.Extensions;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public async Task<PagedList<MediaTypeApiModel>> GetAllMediaType(int pageNumber, int pageSize)
    {
        var mediaTypes = await _mediaTypeRepository!.GetAll(pageNumber, pageSize);
        var mediaTypeApiModels = mediaTypes.ConvertAll().ToList();

        foreach (var mediaType in mediaTypeApiModels)
        {
            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800))
                    .AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(604800);

            _cache!.Set(string.Concat("MediaType-", mediaType.Id), mediaType, (TimeSpan)cacheEntryOptions);
        }
        var newPagedList = new PagedList<MediaTypeApiModel>(mediaTypeApiModels, mediaTypes.TotalCount, mediaTypes.CurrentPage, mediaTypes.PageSize);
        return newPagedList;
    }

    public async Task<MediaTypeApiModel?> GetMediaTypeById(int? id)
    {
        var mediaTypeApiModelCached = _cache!.Get<MediaTypeApiModel>(string.Concat("MediaType-", id));

        if (mediaTypeApiModelCached != null)
        {
            return mediaTypeApiModelCached;
        }
        else
        {
            var mediaType = await _mediaTypeRepository!.GetById(id);
            if (mediaType == null) return null;
            var mediaTypeApiModel = mediaType.Convert();
            //mediaTypeApiModel.Tracks = (await GetTrackByMediaTypeId(mediaTypeApiModel.Id)).ToList();

            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800))
                    .AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(604800);

            _cache!.Set(string.Concat("MediaType-", mediaTypeApiModel.Id), mediaTypeApiModel,
                (TimeSpan)cacheEntryOptions);

            return mediaTypeApiModel;
        }
    }

    public async Task<MediaTypeApiModel> AddMediaType(MediaTypeApiModel newMediaTypeApiModel)
    {
        await _mediaTypeValidator.ValidateAndThrowAsync(newMediaTypeApiModel);

        var mediaType = newMediaTypeApiModel.Convert();

        mediaType = await _mediaTypeRepository!.Add(mediaType);
        newMediaTypeApiModel.Id = mediaType.Id;
        return newMediaTypeApiModel;
    }

    public async Task<bool> UpdateMediaType(MediaTypeApiModel mediaTypeApiModel)
    {
        await _mediaTypeValidator.ValidateAndThrowAsync(mediaTypeApiModel);

        var mediaType = await _mediaTypeRepository!.GetById(mediaTypeApiModel.Id);

        if (mediaType == null) return false;
        mediaType.Id = mediaTypeApiModel.Id;
        mediaType.Name = mediaTypeApiModel.Name ?? string.Empty;

        return await _mediaTypeRepository.Update(mediaType);
    }

    public Task<bool> DeleteMediaType(int id)
        => _mediaTypeRepository!.Delete(id);
}