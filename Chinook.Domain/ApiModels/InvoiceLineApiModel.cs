using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public partial class InvoiceLineApiModel : BaseApiModel, IConvertModel<InvoiceLine>
{
    public int? InvoiceId { get; set; }
    public int? TrackId { get; set; }
    public string TrackName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public virtual InvoiceApiModel Invoice { get; set; } = null!;

    public virtual TrackApiModel Track { get; set; } = null!;

    public InvoiceLine Convert() =>
        new()
        {
            Id = Id,
            InvoiceId = InvoiceId,
            TrackId = TrackId,
            UnitPrice = UnitPrice,
            Quantity = Quantity
        };
}