using Chinook.Domain.Helpers;

namespace Chinook.Domain.ApiModels;

public class BaseApiModel : Representation
{
    public int Id { get; set; }
}