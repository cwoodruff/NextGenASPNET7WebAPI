using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Chinook.FluentMinAPI.Bootstrapper;

public static class RequestPipelineBuilder
{
    public static void Configure(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
    }
}