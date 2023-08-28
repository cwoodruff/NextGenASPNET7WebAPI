using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public partial class InvoiceApiModel : BaseApiModel, IConvertModel<Invoice>
{
    public int? CustomerId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public string? BillingAddress { get; set; }

    public string? BillingCity { get; set; }

    public string? BillingState { get; set; }

    public string? BillingCountry { get; set; }

    public string? BillingPostalCode { get; set; }

    public decimal Total { get; set; }

    public virtual CustomerApiModel Customer { get; set; } = null!;

    public virtual ICollection<InvoiceLineApiModel> InvoiceLines { get; set; } = new List<InvoiceLineApiModel>();

    public Invoice Convert() =>
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