﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoService.Application.Commands;

namespace VideoService.Api.Modules;

public class VideoModule : CarterModule
{
    public VideoModule() : base("/api/videos")
    {
        WithTags("Videos");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/{videoId:guid}", async (Guid videoId, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetVideoCommand(videoId), cancellationToken);
            return Results.Ok(result);
        }).WithOpenApi(o =>
            {
                o.Description = "Get video details using video Id";
                return o;
            });

        app.MapGet("/", async (int? pageLength, int? pageNumber, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetVideoListCommand(pageLength, pageNumber), cancellationToken);
            return Results.Ok(result);
        }).WithOpenApi(o =>
        {
            o.Description = "Get all videos in paginated list.";
            return o;
        }); ;
    }
}
