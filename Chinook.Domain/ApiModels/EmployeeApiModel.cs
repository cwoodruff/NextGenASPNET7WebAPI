using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public partial class EmployeeApiModel : BaseApiModel, IConvertModel<Employee>
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Title { get; set; }

    public int? ReportsTo { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? HireDate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<CustomerApiModel> Customers { get; set; } = new List<CustomerApiModel>();

    public virtual ICollection<EmployeeApiModel> InverseReportsToNavigation { get; set; } =
        new List<EmployeeApiModel>();

    public virtual EmployeeApiModel? ReportsToNavigation { get; set; }

    public Employee Convert() =>
        new()
        {
            Id = Id,
            LastName = LastName ?? string.Empty,
            FirstName = FirstName ?? string.Empty,
            Title = Title ?? string.Empty,
            ReportsTo = ReportsTo,
            BirthDate = BirthDate,
            HireDate = HireDate,
            Address = Address ?? string.Empty,
            City = City ?? string.Empty,
            State = State ?? string.Empty,
            Country = Country ?? string.Empty,
            PostalCode = PostalCode ?? string.Empty,
            Phone = Phone ?? string.Empty,
            Fax = Fax ?? string.Empty,
            Email = Email ?? string.Empty
        };
}