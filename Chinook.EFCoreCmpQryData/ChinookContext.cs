using Microsoft.EntityFrameworkCore;
using Chinook.Domain.Entities;

namespace Chinook.EFCoreCmpQryData;

public partial class ChinookContext : DbContext
{
    public ChinookContext(DbContextOptions<ChinookContext> options)
        : base(options)
    {
    }

    // Compiled Queries

    public Task<bool> AlbumExists(int id) => _queryAlbumExists(this, id);

    public IAsyncEnumerable<Album> GetAllAlbums() => _queryGetAllAlbums(this);

    public Task<Album?> GetAlbum(int id) => _queryGetAlbum(this, id);

    public IAsyncEnumerable<Album> GetAlbumsByArtistId(int id) => _queryGetAlbumsByArtistId(this, id);

    public IAsyncEnumerable<Artist> GetAllArtists() => _queryGetAllArtists(this);

    public Task<Artist?> GetArtist(int id) => _queryGetArtist(this, id);

    public IAsyncEnumerable<Customer> GetAllCustomers() => _queryGetAllCustomers(this);

    public Task<Customer?> GetCustomer(int id) => _queryGetCustomer(this, id);

    public IAsyncEnumerable<Customer> GetCustomerBySupportRepId(int id) => _queryGetCustomerBySupportRepId(this, id);

    public IAsyncEnumerable<Employee> GetAllEmployees() => _queryGetAllEmployees(this);

    public Task<Employee?> GetEmployee(int id) => _queryGetEmployee(this, id);

    public IAsyncEnumerable<Employee> GetEmployeeDirectReports(int id) => _queryGetDirectReports(this, id);

    public Task<Employee> GetEmployeeGetReportsTo(int id) => _queryGetReportsTo(this, id);

    public IAsyncEnumerable<Genre> GetAllGenres() => _queryGetAllGenres(this);

    public Task<Genre?> GetGenre(int id) => _queryGetGenre(this, id);

    public IAsyncEnumerable<InvoiceLine> GetAllInvoiceLines() => _queryGetAllInvoiceLines(this);

    public Task<InvoiceLine?> GetInvoiceLine(int id) => _queryGetInvoiceLine(this, id);

    public IAsyncEnumerable<InvoiceLine> GetInvoiceLinesByInvoiceId(int id) =>
        _queryGetInvoiceLinesByInvoiceId(this, id);

    public IAsyncEnumerable<InvoiceLine> GetInvoiceLinesByTrackId(int id) => _queryGetInvoiceLinesByTrackId(this, id);

    public IAsyncEnumerable<Invoice> GetAllInvoices() => _queryGetAllInvoices(this);

    public Task<Invoice?> GetInvoice(int id) => _queryGetInvoice(this, id);

    public IAsyncEnumerable<Invoice> GetInvoicesByCustomerId(int id) => _queryGetInvoicesByCustomerId(this, id);

    public IAsyncEnumerable<MediaType> GetAllMediaTypes() => _queryGetAllMediaTypes(this);

    public Task<MediaType?> GetMediaType(int id) => _queryGetMediaType(this, id);

    public IAsyncEnumerable<Playlist> GetAllPlaylists() => _queryGetAllPlaylists(this);

    public Task<Playlist?> GetPlaylist(int id) => _queryGetPlaylist(this, id);

    public IAsyncEnumerable<Playlist> GetPlaylistsByTrackId(int id) => _queryGetPlaylistsByTrackId(this, id);

    public IAsyncEnumerable<Track> GetAllTracks() => _queryGetAllTracks(this);

    public Task<Track?> GetTrack(int id) => _queryGetTrack(this, id);

    public IAsyncEnumerable<Track> GetTracksByAlbumId(int id) => _queryGetTracksByAlbumId(this, id);

    public IAsyncEnumerable<Track> GetTracksByGenreId(int id) => _queryGetTracksByGenreId(this, id);

    public IAsyncEnumerable<Track> GetTracksByMediaTypeId(int id) => _queryGetTracksByMediaTypeId(this, id);

    public IAsyncEnumerable<Track> GetTracksByArtistId(int id) => _queryGetTracksByArtistId(this, id);

    public IAsyncEnumerable<Track> GetTracksByInvoiceId(int id) => _queryGetTracksByInvoiceId(this, id);

    public IAsyncEnumerable<Invoice> GetInvoicesByEmployeeId(int id) => _queryGetInvoicesByEmployeeId(this, id);

    public IAsyncEnumerable<Track> GetTracksByPlaylistId(int id) => _queryGetTracksByPlaylistId(this, id);

    // 

    private static readonly Func<ChinookContext, int, Task<bool>> _queryAlbumExists =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Albums.Any(a => a.Id == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<Album>> _queryGetAllAlbums =
        EF.CompileAsyncQuery((ChinookContext db) => db.Albums);

    private static readonly Func<ChinookContext, int, Task<Album?>> _queryGetAlbum =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Albums.FirstOrDefault(a => a.Id == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Album>> _queryGetAlbumsByArtistId =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Albums.Where(a => a.ArtistId == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<Artist>> _queryGetAllArtists =
        EF.CompileAsyncQuery((ChinookContext db) => db.Artists);

    private static readonly Func<ChinookContext, int, Task<Artist?>> _queryGetArtist =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Artists.FirstOrDefault(a => a.Id == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<Customer>> _queryGetAllCustomers =
        EF.CompileAsyncQuery((ChinookContext db) => db.Customers);

    private static readonly Func<ChinookContext, int, Task<Customer?>> _queryGetCustomer =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Customers.FirstOrDefault(c => c.Id == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Customer>> _queryGetCustomerBySupportRepId =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Customers.Where(a => a.SupportRepId == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<Employee>> _queryGetAllEmployees =
        EF.CompileAsyncQuery((ChinookContext db) => db.Employees);

    private static readonly Func<ChinookContext, int, Task<Employee?>> _queryGetEmployee =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Employees.FirstOrDefault(e => e.Id == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Employee>> _queryGetDirectReports =
        EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.Employees.Where(e => e.ReportsTo == id));

    private static readonly Func<ChinookContext, int, Task<Employee>> _queryGetReportsTo =
        EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.Employees.First(e => e.ReportsTo == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<Genre>> _queryGetAllGenres =
        EF.CompileAsyncQuery((ChinookContext db) => db.Genres);

    private static readonly Func<ChinookContext, int, Task<Genre?>> _queryGetGenre =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Genres.FirstOrDefault(g => g.Id == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<InvoiceLine>> _queryGetAllInvoiceLines =
        EF.CompileAsyncQuery((ChinookContext db) => db.InvoiceLines);

    private static readonly Func<ChinookContext, int, Task<InvoiceLine?>> _queryGetInvoiceLine =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.InvoiceLines.FirstOrDefault(i => i.Id == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<InvoiceLine>> _queryGetInvoiceLinesByInvoiceId
        = EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.InvoiceLines.Where(a => a.InvoiceId == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<InvoiceLine>> _queryGetInvoiceLinesByTrackId =
        EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.InvoiceLines.Where(a => a.TrackId == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<Invoice>> _queryGetAllInvoices =
        EF.CompileAsyncQuery((ChinookContext db) => db.Invoices);

    private static readonly Func<ChinookContext, int, Task<Invoice?>> _queryGetInvoice =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Invoices.FirstOrDefault(i => i.Id == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Invoice>> _queryGetInvoicesByCustomerId =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Invoices.Where(a => a.CustomerId == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<MediaType>> _queryGetAllMediaTypes =
        EF.CompileAsyncQuery((ChinookContext db) => db.MediaTypes);

    private static readonly Func<ChinookContext, int, Task<MediaType?>> _queryGetMediaType =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.MediaTypes.FirstOrDefault(m => m.Id == id));

    private static readonly Func<ChinookContext, IAsyncEnumerable<Playlist>> _queryGetAllPlaylists =
        EF.CompileAsyncQuery((ChinookContext db) => db.Playlists);

    private static readonly Func<ChinookContext, int, Task<Playlist?>> _queryGetPlaylist =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Playlists.FirstOrDefault(p => p.Id == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Playlist>> _queryGetPlaylistsByTrackId =
        EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.Tracks.Where(t => t.Id == id).SelectMany(t => t.Playlists));

    private static readonly Func<ChinookContext, IAsyncEnumerable<Track>> _queryGetAllTracks =
        EF.CompileAsyncQuery((ChinookContext db) => db.Tracks);

    private static readonly Func<ChinookContext, int, Task<Track?>> _queryGetTrack =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Tracks.FirstOrDefault(t => t.Id == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Track>> _queryGetTracksByAlbumId =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Tracks.Where(a => a.AlbumId == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Track>> _queryGetTracksByGenreId =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Tracks.Where(a => a.GenreId == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Track>> _queryGetTracksByMediaTypeId =
        EF.CompileAsyncQuery((ChinookContext db, int id) => db.Tracks.Where(a => a.MediaTypeId == id));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Track>> _queryGetTracksByArtistId =
        EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.Albums.Where(a => a.ArtistId == id).SelectMany(t => t.Tracks));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Track>> _queryGetTracksByInvoiceId =
        EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.Tracks.Where(c => c.InvoiceLines.Any(o => o.InvoiceId == id)));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Invoice>> _queryGetInvoicesByEmployeeId =
        EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.Customers.Where(a => a.SupportRepId == id).SelectMany(t => t.Invoices));

    private static readonly Func<ChinookContext, int, IAsyncEnumerable<Track>> _queryGetTracksByPlaylistId =
        EF.CompileAsyncQuery((ChinookContext db, int id) =>
            db.Playlists.Where(a => a.Id == id).SelectMany(t => t.Tracks));

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<AlbumWithArtistName> AlbumWithArtistNames { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Domain.Entities.Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

    public virtual DbSet<MediaType> MediaTypes { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Album__97B4BE370AD2A005");

            entity.ToTable("Album");

            entity.HasIndex(e => e.ArtistId, "IFK_Artist_Album");

            entity.HasIndex(e => e.Id, "IPK_ProductItem");

            entity.Property(e => e.Title).HasMaxLength(160);

            entity.HasOne(d => d.Artist).WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Album__ArtistId__276EDEB3");
        });

        modelBuilder.Entity<AlbumWithArtistName>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AlbumWithArtistName");

            entity.Property(e => e.Name).HasMaxLength(120);
            entity.Property(e => e.Title).HasMaxLength(160);
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Artist__25706B5007020F21");

            entity.ToTable("Artist");

            entity.HasIndex(e => e.Id, "IPK_Artist");

            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Domain.Entities.Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__A4AE64D8164452B1");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.SupportRepId, "IFK_Employee_Customer");

            entity.HasIndex(e => e.Id, "IPK_Customer");

            entity.Property(e => e.Address).HasMaxLength(70);
            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.Company).HasMaxLength(80);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.FirstName).HasMaxLength(40);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(40);

            entity.HasOne(d => d.SupportRep).WithMany(p => p.Customers)
                .HasForeignKey(d => d.SupportRepId)
                .HasConstraintName("FK__Customer__Suppor__2C3393D0");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__7AD04F111273C1CD");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.ReportsTo, "IFK_Employee_ReportsTo");

            entity.HasIndex(e => e.Id, "IPK_Employee");

            entity.Property(e => e.Address).HasMaxLength(70);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(40);
            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK__Employee__Report__2B3F6F97");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__0385057E7F60ED59");

            entity.ToTable("Genre");

            entity.HasIndex(e => e.Id, "IPK_Genre");

            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__D796AAB51A14E395");

            entity.ToTable("Invoice");

            entity.HasIndex(e => e.CustomerId, "IFK_Customer_Invoice");

            entity.HasIndex(e => e.Id, "IPK_Invoice");

            entity.Property(e => e.BillingAddress).HasMaxLength(70);
            entity.Property(e => e.BillingCity).HasMaxLength(40);
            entity.Property(e => e.BillingCountry).HasMaxLength(40);
            entity.Property(e => e.BillingPostalCode).HasMaxLength(10);
            entity.Property(e => e.BillingState).HasMaxLength(40);
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__Custome__2D27B809");
        });

        modelBuilder.Entity<InvoiceLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceL__0D760AD91DE57479");

            entity.ToTable("InvoiceLine");

            entity.HasIndex(e => e.InvoiceId, "IFK_Invoice_InvoiceLine");

            entity.HasIndex(e => e.TrackId, "IFK_ProductItem_InvoiceLine");

            entity.HasIndex(e => e.Id, "IPK_InvoiceLine");

            entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceLi__Invoi__2F10007B");

            entity.HasOne(d => d.Track).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceLi__Track__2E1BDC42");
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MediaTyp__0E6FCB7203317E3D");

            entity.ToTable("MediaType");

            entity.HasIndex(e => e.Id, "IPK_MediaType");

            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Playlist__B30167A021B6055D");

            entity.ToTable("Playlist");

            entity.HasIndex(e => e.Id, "IPK_Playlist");

            entity.Property(e => e.Name).HasMaxLength(120);

            entity.HasMany(d => d.Tracks).WithMany(p => p.Playlists)
                .UsingEntity<Dictionary<string, object>>(
                    "PlaylistTrack",
                    r => r.HasOne<Track>().WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PlaylistT__Track__300424B4"),
                    l => l.HasOne<Playlist>().WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PlaylistT__Playl__30F848ED"),
                    j =>
                    {
                        j.HasKey("PlaylistId", "TrackId").HasName("PK__Playlist__A4A6282E25869641");
                        j.ToTable("PlaylistTrack");
                        j.HasIndex(new[] { "PlaylistId" }, "IFK_Playlist_PlaylistTrack");
                        j.HasIndex(new[] { "TrackId" }, "IFK_Track_PlaylistTrack");
                        j.HasIndex(new[] { "PlaylistId" }, "IPK_PlaylistTrack");
                    });
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Track__7A74F8E00EA330E9");

            entity.ToTable("Track");

            entity.HasIndex(e => e.AlbumId, "IFK_Album_Track");

            entity.HasIndex(e => e.GenreId, "IFK_Genre_Track");

            entity.HasIndex(e => e.MediaTypeId, "IFK_MediaType_Track");

            entity.HasIndex(e => e.Id, "IPK_Track");

            entity.Property(e => e.Composer).HasMaxLength(220);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Album).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK__Track__AlbumId__286302EC");

            entity.HasOne(d => d.Genre).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Track__GenreId__2A4B4B5E");

            entity.HasOne(d => d.MediaType).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Track__MediaType__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}