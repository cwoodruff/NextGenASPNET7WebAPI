using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public partial class CustomerApiModel : BaseApiModel, IConvertModel<Customer>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Company { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string Email { get; set; } = null!;
    public int? SupportRepId { get; set; }
    public string? SupportRepName { get; set; }

    public virtual ICollection<InvoiceApiModel> Invoices { get; set; } = new List<InvoiceApiModel>();

    public virtual EmployeeApiModel? SupportRep { get; set; }

    public Customer Convert() =>
        new()
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            Company = Company,
            Address = Address,
            City = City,
            State = State,
            Country = Country,
            PostalCode = PostalCode,
            Phone = Phone,
            Fax = Fax,
            Email = Email,
            SupportRepId = SupportRepId
        };
}