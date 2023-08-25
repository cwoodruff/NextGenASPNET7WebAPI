using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chinook.Domain.Helpers;

public class ListRepresentationEnricher : IAsyncResultFilter
{
    private readonly IEnumerable<IListEnricher> enrichers;

    public ListRepresentationEnricher(IEnumerable<IListEnricher> enrichers)
    {
        this.enrichers = enrichers;
    }
    
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult result)
        {
            var value = result.Value;
            foreach (var enricher in enrichers)
            {
                if (await enricher.Match(value!))
                {
                    await enricher.Process((value as List<object>)!);
                }
            }
        }
        // call this or everything is blank!
        await next();
    }
}