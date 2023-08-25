namespace Chinook.Domain.Helpers;

public abstract class ListEnricher<T> : IListEnricher
{
    public virtual Task<bool> Match(object target) => Task.FromResult(target is List<T>);

    public abstract Task Process(List<object> representations);
}