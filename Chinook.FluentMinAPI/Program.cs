using Chinook.FluentMinAPI.Api;
using Chinook.FluentMinAPI.Bootstrapper;

var app = AppBuilder.GetApp(args);

// Configure Request Pipeline
RequestPipelineBuilder.Configure(app);

// Configure APIs 
AlbumApi.RegisterApis(app);
ArtistApi.RegisterApis(app);
CustomerApi.RegisterApis(app);
EmployeeApi.RegisterApis(app);
GenreApi.RegisterApis(app);
InvoiceApi.RegisterApis(app);
InvoiceLineApi.RegisterApis(app);
MediaType.RegisterApis(app);
PlaylistApi.RegisterApis(app);
TrackApi.RegisterApis(app);

// Start the app
app.Run();