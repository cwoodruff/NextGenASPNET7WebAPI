using Chinook.Domain.ApiModels;
using Chinook.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Chinook.Domain.Enrichers;

public class AlbumEnricher : Enricher<AlbumApiModel>
{
    private readonly IHttpContextAccessor _accessor;
    private readonly LinkGenerator _linkGenerator;

    public AlbumEnricher(IHttpContextAccessor accessor, LinkGenerator linkGenerator)
    {
        _accessor = accessor;
        _linkGenerator = linkGenerator;
    }

    public override Task Process(AlbumApiModel? representation)
    {
        var httpContext = _accessor.HttpContext;

        var url = _linkGenerator.GetUriByName(
            httpContext!,
            "album",
            new { id = representation!.Id },
            scheme: "https"
        );

        representation.AddLink(new Link
        {
            Id = representation.Id.ToString(),
            Label = $"Album: {representation.Title} #{representation.Id}",
            Url = url!
        });

        return Task.CompletedTask;
    }
}