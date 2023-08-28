using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;

namespace Chinook.Domain.Entities;

public partial class Invoice : BaseEntity, IConvertModel<InvoiceApiModel>
{
    public int? CustomerId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public string? BillingAddress { get; set; }

    public string? BillingCity { get; set; }

    public string? BillingState { get; set; }

    public string? BillingCountry { get; set; }

    public string? BillingPostalCode { get; set; }

    public decimal Total { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();

    public InvoiceApiModel Convert() =>
        new()
        {
            Id = Id,
            CustomerId = CustomerId,
            InvoiceDate = InvoiceDate,
            BillingAddress = BillingAddress,
            BillingCity = BillingCity,
            BillingState = BillingState,
            BillingCountry = BillingCountry,
            BillingPostalCode = BillingPostalCode,
            Total = Total
        };
}