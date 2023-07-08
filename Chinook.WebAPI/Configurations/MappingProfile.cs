using AutoMapper;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Entities;

namespace Chinook.WebAPI.Configurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Album, AlbumApiModel>();
    }
}