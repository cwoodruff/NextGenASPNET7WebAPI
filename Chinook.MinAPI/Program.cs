using Chinook.MinAPI.Api;
using Chinook.MinAPI.Bootstrapper;

var app = AppBuilder.GetApp(args);

// Configure Request Pipeline
RequestPipelineBuilder.Configure(app);

// Configure APIs 
AlbumsApi.RegisterApis(app);

// Start the app
app.Run();