using Microsoft.AspNetCore.Mvc;
using UrlShortner.Application.Exceptions;
using UrlShortner.Web;
using UrlShortner.Web.Dtos;
using Shortener = UrlShortner.Application.UrlShortener;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInMemoryShortner();
var app = builder.Build();
app.UseHttpsRedirection();


app.MapGet("/{shortCode}", async ([FromRoute] string shortCode, [FromServices] Shortener shortener) =>
{
    try
    {
        var url = await shortener.GetUrlAsync(shortCode);
        return Results.Redirect(url, true);
    }
    catch (KeyNotFoundException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/shorten", async ([FromBody] ShortUrlRequest request, [FromServices] Shortener shortener, HttpContext httpCtx) =>
{
    try
    {
        var model = await shortener.SaveAsync(request.Url);
        string shortUrl = $"{httpCtx.Request.Scheme}://{httpCtx.Request.Host}/{model.Code}";
        var response = new ShortUrlResponse(model.Url, model.Code, model.CreatedAt, shortUrl);
        return Results.Ok(response);
    }
    catch (BadUrlException excption)
    {
        return Results.BadRequest(excption.Message);
    }
    catch (CollisionException _)
    {
        return Results.Conflict("Error occurred, Please retry");
    }
});

app.Run();