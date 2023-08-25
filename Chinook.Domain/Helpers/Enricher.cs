namespace Chinook.Domain.Helpers;

public abstract class Enricher<T> : IEnricher where T : class
{
    public virtual Task<bool> Match(object target) => Task.FromResult(target is T);
    public Task Process(object representation) => Process(representation as T);
    public abstract Task Process(T? representation);
}