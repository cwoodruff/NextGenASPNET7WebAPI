namespace Chinook.Domain.ApiModels;

public partial class InvoiceLineApiModel : BaseApiModel
{
    public int InvoiceId { get; set; }

    public int TrackId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public virtual InvoiceApiModel Invoice { get; set; } = null!;

    public virtual TrackApiModel Track { get; set; } = null!;
}
