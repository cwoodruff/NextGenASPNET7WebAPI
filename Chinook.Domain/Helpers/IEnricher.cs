namespace Chinook.Domain.Helpers;

public interface IEnricher
{
    Task<bool> Match(object target);
    Task Process(object representation);
}